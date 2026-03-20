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

                // Prepare HIU Consent Request Object
                var request = new
                {
                    abhaAddress = _abhaAddress,
                    purpose = "CAREMGT", // Care Management
                    dateFrom = dtFrom.Value.ToString("yyyy-MM-dd"),
                    dateTo = dtTo.Value.ToString("yyyy-MM-dd"),
                    hiTypes = hiTypes,
                    requester = GlobalConfig.HipName
                };

                string response = await _abdmService.RequestConsentAsync(request);

                MessageBox.Show(response, "HIU Consent Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
