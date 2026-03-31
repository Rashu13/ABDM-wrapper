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
                var addResponse = await _abdmService.AddPatientAsync(patient);

                // Step 2: Initiate Linking (OTP)
                var linkReq = new LinkRequest
                {
                    requestId = Guid.NewGuid().ToString(),
                    requesterId = GlobalConfig.HipId,
                    abhaAddress = patient.abhaAddress,
                    careContexts = new List<CareContext>
                    {
                        new CareContext { 
                            referenceNumber = "OPD-" + DateTime.Now.Ticks.ToString().Substring(10), 
                            display = "OPD Consultation - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm"), 
                            hiType = "OPConsultation" 
                        }
                    }
                };

                var linkResponse = await _abdmService.InitiateLinkingAsync(linkReq);

                if (linkResponse.Contains("ACCEPTED"))
                {
                    // Parse linkRefNumber from response (PDF Page 10/11)
                    // Format usually: {"clientRequestId":"...","httpStatusCode":"ACCEPTED","message":"...","linkRefNumber":"cc-123..."}
                    string linkRefNumber = "";
                    if (linkResponse.Contains("linkRefNumber")) {
                        var dynResponse = JsonConvert.DeserializeObject<dynamic>(linkResponse);
                        linkRefNumber = (string)dynResponse.linkRefNumber;
                    }

                    // Open the modern polling screen instead of the old OTP screen
                    using (var pollForm = new LinkingStatusPollForm(linkReq.requestId))
                    {
                        var result = pollForm.ShowDialog(this);
                        if (result == DialogResult.OK)
                        {
                            // Success! Patient is linked.
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Linking could not be initiated: " + linkResponse, "ABDM Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
