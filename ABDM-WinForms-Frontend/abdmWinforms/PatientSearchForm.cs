using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class PatientSearchForm : Form
    {
        private readonly AbdmService _abdmService;
        private PatientModel _currentPatient;
        private string _lastConsentRequestId;

        public PatientSearchForm()
        {
            InitializeComponent();
            _abdmService = new AbdmService();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string abha = txtSearchAbha.Text.Trim();
            if (string.IsNullOrWhiteSpace(abha) || abha.Contains("enter abha"))
            {
                MessageBox.Show("Please enter a valid ABHA address.");
                return;
            }

            try
            {
                btnSearch.Enabled = false;
                btnSearch.Text = "Searching...";

                // Call the Wrapper API: GET /v3/patient/{abha}
                string jsonResponse = await _abdmService.SearchPatientAsync(abha);

                if (jsonResponse.Contains("Patient not found"))
                {
                    pnlDetails.Visible = false;
                    MessageBox.Show("Patient not registered in local database.\nPlease register them first.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show registration form with pre-filled ABHA
                    new PatientRegistrationForm(abha).ShowDialog();
                }
                else
                {
                    // Map the response to PatientModel
                    // FIX: Check if it's a valid JSON object starting with '{'. 
                    // If it starts with 'Error:', it's a backend exception.
                    if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.StartsWith("Error:") || !jsonResponse.Trim().StartsWith("{"))
                    {
                        string displayMsg = "Failed to fetch patient data.";
                        if (jsonResponse.StartsWith("Error:")) displayMsg = jsonResponse;
                        else if (jsonResponse.Contains("<html")) displayMsg = "Server returned an HTML error (likely the service is down or URL is wrong).";
                        
                        MessageBox.Show(displayMsg + "\n\nResponse received: " + (jsonResponse.Length > 100 ? jsonResponse.Substring(0, 100) + "..." : jsonResponse), 
                                        "ABDM Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _currentPatient = JsonConvert.DeserializeObject<PatientModel>(jsonResponse);

                    // FIX: Check if the patient truly has a name (to avoid empty objects)
                    if (_currentPatient != null && !string.IsNullOrEmpty(_currentPatient.name))
                    {
                        lblName.Text = string.Format("Patient: {0}", _currentPatient.name);
                        lblGender.Text = string.Format("Gender: {0}", (_currentPatient.gender ?? "N/A"));
                        lblDob.Text = string.Format("DOB: {0}", (_currentPatient.dateOfBirth ?? "N/A"));
                        lblStatus.Text = "✅ ABDM VERIFIED & LINKED";
                        lblStatus.ForeColor = System.Drawing.Color.SeaGreen;
                        lblStatus.Font = new System.Drawing.Font(lblStatus.Font, System.Drawing.FontStyle.Bold);

                        pnlDetails.Visible = true;
                        btnWritePrescription.Visible = true;
                        btnStartLinking.Visible = true;
                        btnRequestConsent.Visible = true;
                        btnViewHistory.Visible = true;
                    }
                    else
                    {
                        // If name is empty, it's a fail
                        lblStatus.Text = "Status: PATIENT NOT FOUND";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        if (jsonResponse.Contains("No Patient found") || jsonResponse.Contains("Error"))
                        {
                            MessageBox.Show("Patient not found in local system.\n\nPlease click 'REGISTER NEW PATIENT' to add them to your hospital first.", "Registration Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlDetails.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
            finally
            {
                btnSearch.Enabled = true;
                btnSearch.Text = "SEARCH";
            }
        }

        private void btnRequestAccess_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                using (var consentForm = new ConsentRequestForm(_currentPatient.abhaAddress, _currentPatient.name))
                {
                    if (consentForm.ShowDialog(this) == DialogResult.OK)
                    {
                        _lastConsentRequestId = consentForm.LastRequestId;
                    }
                }
            }
        }

        private async void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                if (string.IsNullOrEmpty(_lastConsentRequestId))
                {
                    MessageBox.Show("Please send a 'CONSENT REQUEST' first to view health records.", "Request Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnViewHistory.Enabled = false;
                btnViewHistory.Text = "CHECKING STATUS...";

                var statusResponse = await _abdmService.GetConsentStatusAsync(_lastConsentRequestId);

                if (statusResponse != null && statusResponse.consentDetails != null && statusResponse.consentDetails.consent != null && statusResponse.consentDetails.consent.Count > 0)
                {
                    var grantedArtifact = statusResponse.consentDetails.consent.FirstOrDefault(a => a.status == "GRANTED");
                    if (grantedArtifact != null && grantedArtifact.consentArtefacts != null && grantedArtifact.consentArtefacts.Count > 0)
                    {
                        using (var viewerForm = new HealthRecordViewerForm(grantedArtifact.consentArtefacts[0].id, _currentPatient.name))
                        {
                            viewerForm.ShowDialog(this);
                        }
                    }
                    else
                    {
                        string currentStatus = statusResponse.consentDetails.consent[0].status;
                        MessageBox.Show(string.Format("Current Consent Status: {0}\n\nAsk the patient to GRANT the request in their ABHA app.", currentStatus), "Access Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Waiting for ABDM Gateway to process the request. Status: PENDING", "Access Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnViewHistory.Enabled = true;
                btnViewHistory.Text = "VIEW FOLDER (M3)";
            }
        }

        private void btnWritePrescription_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                // To show data in PHR App, we MUST use a linked care context.
                string linkedContext = "";
                if (_currentPatient.careContexts != null && _currentPatient.careContexts.Count > 0)
                {
                    linkedContext = _currentPatient.careContexts[0].referenceNumber;
                }
                else
                {
                    MessageBox.Show("This patient has NO linked care contexts.\n\nPlease 'START OTP LINKING (M2)' first, otherwise the prescription won't show in their ABHA App.", "Linking Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                using (var prescriptionForm = new PrescriptionForm(
                    _currentPatient.abhaAddress, 
                    _currentPatient.name, 
                    _currentPatient.careContexts, 
                    _currentPatient.patientReference, 
                    _currentPatient.gender, 
                    _currentPatient.dateOfBirth))
                {
                    prescriptionForm.ShowDialog(this);
                }
            }
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            // Open the Activity Logs screen
            using (var historyForm = new LinkingHistoryForm())
            {
                historyForm.ShowDialog(this);
            }
        }

        private void btnShowInvite_Click(object sender, EventArgs e)
        {
            // Open the SMS Invitation screen
            using (var inviteForm = new SmsInviteForm())
            {
                inviteForm.ShowDialog(this);
            }
        }

        private void btnStartLinking_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                // Open the Linking Form (PatientRegistrationForm rebranded)
                // Actually, since we already have the profile, we could go straight to token generation
                // For simplicity, we open the registration form with pre-filled details
                // Open the Linking Form with pre-filled details
                var regForm = new PatientRegistrationForm(_currentPatient.abhaAddress);
                regForm.ShowDialog();
            }
        }

        private void btnShowRegistration_Click(object sender, EventArgs e)
        {
            new PatientRegistrationForm(txtSearchAbha.Text.Trim()).ShowDialog();
        }

        private void btnDirectConsent_Click(object sender, EventArgs e)
        {
            // Open consent form directly without requiring a search
            using (var consentForm = new ConsentRequestForm("", "Manual Entry"))
            {
                if (consentForm.ShowDialog(this) == DialogResult.OK)
                {
                    _lastConsentRequestId = consentForm.LastRequestId;
                }
            }
        }

        private async void tmrLiveFeed_Tick(object sender, EventArgs e)
        {
            try
            {
                // Fetch activities from AbdmService
                string jsonResponse = await _abdmService.GetActivitiesAsync();
                var activities = JsonConvert.DeserializeObject<List<string>>(jsonResponse);

                if (activities != null && activities.Count > 0)
                {
                    // Update the sidebar listbox
                    lstLiveActivities.BeginUpdate();
                    lstLiveActivities.Items.Clear();
                    foreach (var activity in activities)
                    {
                        lstLiveActivities.Items.Add(activity);
                    }
                    // Auto-scroll to bottom
                    lstLiveActivities.TopIndex = lstLiveActivities.Items.Count - 1;
                    lstLiveActivities.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                // Silent error for background polling
                Console.WriteLine("Activity Polling Error: " + ex.Message);
            }
        }
        private void btnM3Dashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new abdmWinforms.M3DashboardForm();
            dashboard.Show(this);
        }
    }
}
