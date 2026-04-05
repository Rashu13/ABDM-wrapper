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

        public ConsentRequestForm(string abhaAddress)
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            _abhaAddress = abhaAddress;
            lblPatientAbha.Text = abhaAddress;

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
                if (chkClinicalDoc.Checked) hiTypes.Add("ClinicalDocument");

                // Prepare HIU Consent Request Object with strict UTC ISO format
                var request = new
                {
                    abhaAddress = _abhaAddress,
                    purpose = "CAREMGT", // Care Management
                    dateFrom = dtFrom.Value.Date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    dateTo = dtTo.Value.Date.AddDays(1).AddTicks(-1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    hiTypes = hiTypes,
                    requester = GlobalConfig.HipName
                };

                var response = await _abdmService.RequestConsentAsync(request);

                if (response?.errors != null && response.errors.Count > 0)
                {
                    MessageBox.Show("Error: " + response.errors[0].error.message, "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.LastRequestId = response.clientRequestId;
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
