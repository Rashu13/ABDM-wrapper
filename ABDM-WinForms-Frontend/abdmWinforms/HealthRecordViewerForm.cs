using ABDM_WinForms_Frontend;
using System;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class HealthRecordViewerForm : Form
    {
        private readonly AbdmService _abdmService;
        private readonly string _consentId;

        public HealthRecordViewerForm(string consentId, string patientName)
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            _consentId = consentId;

            label1.Text = "History of " + patientName;
            LoadRecords();
        }

        private async void LoadRecords()
        {
            try
            {
                // Fetch encrypted records tied to this consent
                string json = await _abdmService.FetchRecordsAsync(_consentId);
                
                if (!string.IsNullOrEmpty(json))
                {
                    // For now, let's prettify the JSON or show it as is
                    // In a real app, you'd parse FHIR bits, but showing the real response is better than a mock.
                    rtbContent.Text = "--- ABDM DATA RETRIEVED ---\n\n" + json;
                }
                else
                {
                    rtbContent.Text = "No records found for this consent.";
                }
            }
            catch (Exception ex)
            {
                rtbContent.Text = "Error fetching records: " + ex.Message;
            }
        }
    }
}
