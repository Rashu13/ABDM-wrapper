using ABDM_WinForms_Frontend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class ConsentRequestForm : Form
    {
        private readonly AbdmService _abdmService;
        private readonly string _abhaAddress;
        private readonly string _patientName;

        public ConsentRequestForm(string abhaAddress, string patientName)
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            _abhaAddress = abhaAddress;
            _patientName = patientName;
            txtPatientAbha.Text = abhaAddress;

            // Default ranges
            dtFrom.Value = DateTime.Now.AddMonths(-6);
            dtTo.Value = DateTime.Now;
        }

        public string LastRequestId { get; private set; }

        private async void btnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                btnSendRequest.Enabled = false;
                btnSendRequest.Text = "POSTING REQUEST...";

                var hiTypes = new List<string>();
                if (chkPrescription.Checked) hiTypes.Add("Prescription");
                if (chkDiagnostic.Checked) hiTypes.Add("DiagnosticReport");
                if (chkOPD.Checked) hiTypes.Add("OPConsultation");
                if (chkDischarge.Checked) hiTypes.Add("DischargeSummary");
                if (chkImmunization.Checked) hiTypes.Add("ImmunizationRecord");
                if (chkHealthDoc.Checked) hiTypes.Add("HealthDocumentRecord");
                if (chkWellness.Checked) hiTypes.Add("WellnessRecord");
                // ClinicalDocument is not supported by this Gateway version, so we skip it.

                // Prepare HIU Consent Request Object with strict V3 compliance
                var request = new
                {
                    purpose = new { 
                        text = "Care Management", 
                        code = "CAREMGT", 
                        refUri = "https://nha.gov.in/terminology/care-management" 
                    },
                    patient = new { id = txtPatientAbha.Text.Trim() },
                    hiu = new { id = GlobalConfig.HipId }, // HIU ID same as HIP for this wrapper
                    requester = new { 
                        name = GlobalConfig.HipName, 
                        identifier = new { 
                            type = "REGNO", 
                            value = GlobalConfig.HipId, 
                            system = "https://www.mciindia.org" 
                        } 
                    }, 
                    hiTypes = hiTypes,
                    permission = new
                    {
                        accessMode = "VIEW",
                        dateRange = new
                        {
                            from = dtFrom.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            to = dtTo.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                        },
                        dataEraseAt = DateTime.UtcNow.AddYears(2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), 
                        frequency = new { unit = "HOUR", value = 1, repeats = 0 }
                    }
                };

                var response = await _abdmService.RequestConsentAsync(request);

                if (response?.errors != null && response.errors.Count > 0)
                {
                    MessageBox.Show("Error: " + response.errors[0].error.message, "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.LastRequestId = response.clientRequestId;
                    
                    // Add to Dashboard Tracker
                    GlobalState.ActiveConsentRequests.Add(new ConsentRequestTracker {
                        RequestId = this.LastRequestId,
                        PatientName = _patientName,
                        Status = "INITIATED",
                        ConsentId = null
                    });

                    MessageBox.Show("Consent request sent successfully! \n\nRequest ID: " + this.LastRequestId + "\n\nPlease ask the patient to approve in their ABHA app.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Request failed: " + ex.Message);
            }
            finally
            {
                btnSendRequest.Enabled = true;
                btnSendRequest.Text = "SEND CONSENT REQUEST";
            }
        }
    }
}
