using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class PatientSearchForm : Form
    {
        private readonly AbdmService _abdmService;
        private PatientModel _currentPatient;

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
                    _currentPatient = JsonConvert.DeserializeObject<PatientModel>(jsonResponse);

                    // FIX: Check if the patient truly has a name (to avoid empty objects)
                    if (_currentPatient != null && !string.IsNullOrEmpty(_currentPatient.name))
                    {
                        lblName.Text = "Patient: " + _currentPatient.name;
                        lblGender.Text = "Gender: " + (_currentPatient.gender ?? "N/A");
                        lblDob.Text = "DOB: " + (_currentPatient.dateOfBirth ?? "N/A");
                        lblStatus.Text = "Status: Profile Loaded";
                        lblStatus.ForeColor = System.Drawing.Color.SeaGreen;

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
                        pnlDetails.Visible = false;

                        MessageBox.Show("No valid record found for this ABHA address.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnRequestConsent_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                using (var requestForm = new ConsentRequestForm(_currentPatient.abhaAddress))
                {
                    requestForm.ShowDialog(this);
                }
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (_currentPatient != null)
            {
                // In a real scenario, we'd find the latest 'GRANTED' consentId for this patient
                string dummyConsentId = "CONSENT-" + Guid.NewGuid().ToString().Substring(0, 8);
                using (var viewerForm = new HealthRecordViewerForm(dummyConsentId, _currentPatient.name))
                {
                    viewerForm.ShowDialog(this);
                }
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
                    linkedContext, 
                    _currentPatient.patientReference, 
                    _currentPatient.gender, 
                    _currentPatient.dateOfBirth))
                {
                    prescriptionForm.ShowDialog(this);
                }
            }
        }

        private void btnM3Dashboard_Click(object sender, EventArgs e)
        {
            // Open the M3 Monitor Dashboard
            using (var m3Dashboard = new M3DashboardForm())
            {
                m3Dashboard.ShowDialog(this);
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
    }
}
