using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class PatientRegistrationForm : Form
    {
        private readonly AbdmService _abdmService;

        public PatientRegistrationForm(string prefillAbha = "")
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            if (cmbGender.Items.Count > 0) cmbGender.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(prefillAbha))
            {
                txtAbhaAddress.Text = prefillAbha;
            }
        }

        private async void btnGenerateToken_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtAbhaAddress.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please fill all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGenerateToken.Enabled = false;
                btnGenerateToken.Text = "PROCESSING...";

                // Map Gender
                string genderCode = "O";
                if (cmbGender.SelectedItem.ToString() == "Male") genderCode = "M";
                else if (cmbGender.SelectedItem.ToString() == "Female") genderCode = "F";

                // Prepare Patient Model
                var patient = new PatientModel
                {
                    abhaAddress = txtAbhaAddress.Text.Trim(),
                    abhaNumber = txtAbhaNumber.Text.Trim(),
                    name = txtName.Text.Trim(),
                    gender = genderCode,
                    dateOfBirth = dtpDob.Value.ToString("yyyy-MM-dd"), // Correct format for your V3 wrapper
                    patientMobile = txtMobile.Text.Trim(), 
                    patientReference = "P-" + DateTime.Now.Ticks.ToString().Substring(10),
                    patientDisplay = txtName.Text.Trim(),
                    hipId = GlobalConfig.HipId
                };

                // Step 1: Add to Wrapper DB
                btnGenerateToken.Text = "SAVING PATIENT...";
                var addResponse = await _abdmService.AddPatientAsync(patient);
                if (addResponse.Contains("Error") || addResponse.Contains("Failed"))
                {
                    MessageBox.Show("Failed to save patient to database: " + addResponse, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Initiate Linking (OTP)
                btnGenerateToken.Text = "INITIATING LINK...";
                var linkReq = new LinkRequest
                {
                    requestId = Guid.NewGuid().ToString(),
                    requesterId = GlobalConfig.HipId,
                    abhaAddress = patient.abhaAddress,
                    careContexts = new List<CareContext>
                    {
                        new CareContext { 
                            referenceNumber = "OPD-" + Guid.NewGuid().ToString().Substring(0, 8), 
                            display = "OPD Consultation", 
                            hiType = "OPConsultation" 
                        }
                    }
                };

                var linkResponse = await _abdmService.InitiateLinkingAsync(linkReq);

                // Use case-insensitive check for ACCEPTED
                if (linkResponse.IndexOf("ACCEPTED", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Parse linkRefNumber from response
                    string linkRefNumber = "";
                    try {
                        var dynResponse = JsonConvert.DeserializeObject<dynamic>(linkResponse);
                        linkRefNumber = (string)dynResponse.linkRefNumber;
                    } catch { }

                    // Capture the referenceNumbers from our link request
                    string refNo = linkReq.careContexts[0].referenceNumber;
                    string patRef = patient.patientReference;

                    // Open the modern polling screen
                    using (var pollForm = new LinkingStatusPollForm(linkReq.requestId, patient.abhaAddress, patient.name, refNo, patRef))
                    {
                        var result = pollForm.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            // Success!
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Linking could not be initiated. ABDM Response: " + linkResponse, "ABDM Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGenerateToken.Enabled = true;
                btnGenerateToken.Text = "GENERATE TOKEN";
            }
        }
    }
}
