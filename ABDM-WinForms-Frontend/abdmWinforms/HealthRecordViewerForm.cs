using ABDM_WinForms_Frontend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class HealthRecordViewerForm : Form
    {
        private readonly AbdmService _abdmService;
        private readonly string _consentId;
        private List<HealthRecordSummary> _summaries = new List<HealthRecordSummary>();

        public HealthRecordViewerForm(string consentId, string patientName)
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            _consentId = consentId;

            label1.Text = "History of " + patientName;
            this.dgvRecords.AutoGenerateColumns = false;
            LoadRecords();
        }

        private async void LoadRecords()
        {
            try
            {
                lblStatus.Text = "Initiating data transfer...";
                lblStatus.ForeColor = System.Drawing.Color.Orange;

                // 1. Fetch encrypted records tied to this consent (initiates transfer)
                var initResponse = await _abdmService.FetchRecordsAsync(_consentId);
                
                if (initResponse?.errors != null && initResponse.errors.Count > 0)
                {
                    lblStatus.Text = "Error: " + initResponse.errors[0].error.message;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string requestId = initResponse.clientRequestId;
                if (string.IsNullOrEmpty(requestId))
                {
                    lblStatus.Text = "Failed to get Request ID.";
                    return;
                }

                // 2. Polling for Decrypted Records
                int maxRetries = 15;
                int retryCount = 0;
                HealthInformationV3Response statusResponse = null;

                while (retryCount < maxRetries)
                {
                    lblStatus.Text = string.Format("Polling Gateway for data... (Attempt {0}/{maxRetries})", retryCount + 1);
                    statusResponse = await _abdmService.GetHealthInformationStatusAsync(requestId);

                    if (statusResponse?.decryptedHealthInformationEntries != null && statusResponse.decryptedHealthInformationEntries.Count > 0)
                    {
                        break;
                    }

                    if (statusResponse?.errors != null && statusResponse.errors.Count > 0)
                    {
                        lblStatus.Text = "Polling Error: " + statusResponse.errors[0].error.message;
                        break;
                    }

                    await System.Threading.Tasks.Task.Delay(3000); // Wait 3 seconds before next poll
                    retryCount++;
                }

                if (statusResponse?.decryptedHealthInformationEntries != null && statusResponse.decryptedHealthInformationEntries.Count > 0)
                {
                    lblStatus.Text = "Data Received! Parsing health records...";
                    lblStatus.ForeColor = System.Drawing.Color.SeaGreen;

                    _summaries.Clear();
                    foreach (var entry in statusResponse.decryptedHealthInformationEntries)
                    {
                        if (!string.IsNullOrEmpty(entry.bundleContent))
                        {
                            var parsed = FhirParser.ParseBundle(entry.bundleContent);
                            _summaries.AddRange(parsed);
                        }
                    }

                    dgvRecords.DataSource = null;
                    dgvRecords.DataSource = _summaries;
                    
                    if (_summaries.Count == 0)
                    {
                        rtbContent.Text = "Successfully retrieved data, but no clinical records were found in the bundles.";
                    }
                }
                else
                {
                    lblStatus.Text = "No records found or timeout reached.";
                    lblStatus.ForeColor = System.Drawing.Color.Gray;
                    rtbContent.Text = "The Gateway did not provide health records within the expected time. Please try refreshing later.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "System Error";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                rtbContent.Text = "Error fetching records: " + ex.Message;
            }
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count > 0)
            {
                var summary = dgvRecords.SelectedRows[0].DataBoundItem as HealthRecordSummary;
                if (summary != null)
                {
                    rtbContent.Text = summary.ContentHtml;
                }
            }
        }
    }
}
