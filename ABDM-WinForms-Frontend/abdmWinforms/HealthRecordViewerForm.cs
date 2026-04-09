using ABDM_WinForms_Frontend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
                    string fullError = initResponse.errors[0].error.message;
                    lblStatus.Text = "Error! Dekhne ke liye popup check karein.";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("Gateway Error:\n\n" + fullError, "Data Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string requestId = initResponse.clientRequestId;
                if (string.IsNullOrEmpty(requestId))
                {
                    lblStatus.Text = "Failed to get Request ID.";
                    return;
                }

                // 2. Polling for Decrypted Records (ABDM Data Flow can take time)
                int maxRetries = 30; // Increased to 30 attempts (approx 90-100 seconds total)
                int retryCount = 0;
                HealthInformationV3Response statusResponse = null;

                while (retryCount < maxRetries)
                {
                    lblStatus.Text = string.Format("Fetching health records... (Attempt {0}/{1})", retryCount + 1, maxRetries);
                    statusResponse = await _abdmService.GetHealthInformationStatusAsync(requestId);

                    if (statusResponse?.decryptedHealthInformationEntries != null && statusResponse.decryptedHealthInformationEntries.Count > 0)
                    {
                        break;
                    }

                    if (statusResponse?.errors != null && statusResponse.errors.Count > 0)
                    {
                        Console.WriteLine("Poll Error: " + statusResponse.errors[0].error.message);
                    }

                    await System.Threading.Tasks.Task.Delay(3000); 
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
                    
                    bool hasPdf = !string.IsNullOrEmpty(summary.PdfBase64);
                    btnViewPdf.Enabled = hasPdf;
                    btnViewPdf.BackColor = hasPdf ? System.Drawing.Color.MediumSeaGreen : System.Drawing.Color.LightGray;
                    btnViewPdf.Text = hasPdf ? "📄 View PDF Document" : "❌ No PDF Available";
                }
            }
            else
            {
                btnViewPdf.Enabled = false;
                btnViewPdf.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void btnViewPdf_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count > 0)
            {
                var summary = dgvRecords.SelectedRows[0].DataBoundItem as HealthRecordSummary;
                if (summary != null && !string.IsNullOrEmpty(summary.PdfBase64))
                {
                    try
                    {
                        string tempFile = Path.Combine(Path.GetTempPath(), "ABDM_Record_" + Guid.NewGuid().ToString().Substring(0, 8) + ".pdf");
                        byte[] pdfBytes = Convert.FromBase64String(summary.PdfBase64);
                        File.WriteAllBytes(tempFile, pdfBytes);
                        Process.Start(tempFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not open PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
