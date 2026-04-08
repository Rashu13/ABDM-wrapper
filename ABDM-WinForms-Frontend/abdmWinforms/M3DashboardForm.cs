using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class M3DashboardForm : Form
    {
        private readonly AbdmService _abdmService;
        public M3DashboardForm()
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            SetupGrid();
            RefreshGrid();
            // Initial poll for activities
            UpdateLiveMonitor();
        }

        private void SetupGrid()
        {
            dgvConsents.Columns.Clear();
            dgvConsents.Columns.Add("PatientName", "Patient");
            dgvConsents.Columns.Add("RequestId", "Request ID");
            dgvConsents.Columns.Add("Status", "Status");
            dgvConsents.Columns.Add("ConsentId", "Consent ID");
            
            // Adjust appearance
            dgvConsents.Columns["RequestId"].Visible = false; // Internal tracking
            dgvConsents.Columns["Status"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private void RefreshGrid()
        {
            dgvConsents.Rows.Clear();
            foreach (var req in GlobalState.ActiveConsentRequests)
            {
                int rowIndex = dgvConsents.Rows.Add(req.PatientName, req.RequestId, req.Status, req.ConsentId);
                
                // Color code status
                if (req.Status == "GRANTED") dgvConsents.Rows[rowIndex].Cells["Status"].Style.ForeColor = System.Drawing.Color.SeaGreen;
                else if (req.Status == "EXPIRED" || req.Status == "REVOKED") dgvConsents.Rows[rowIndex].Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                else dgvConsents.Rows[rowIndex].Cells["Status"].Style.ForeColor = System.Drawing.Color.DarkOrange;
            }
            
            lblConsentCount.Text = "- Consents Granted: " + GlobalState.ActiveConsentRequests.Count(r => r.Status == "GRANTED");
        }

        private async void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            if (dgvConsents.SelectedRows.Count == 0) return;

            string requestId = dgvConsents.SelectedRows[0].Cells["RequestId"].Value?.ToString();
            if (string.IsNullOrEmpty(requestId)) return;

            btnRefreshStatus.Enabled = false;
            btnRefreshStatus.Text = "CHECKING...";

            try
            {
                var response = await _abdmService.GetConsentStatusAsync(requestId);
                
                // V3 Structure: response.status and response.consentDetails.consent[...]
                if (response != null && response.consentDetails != null && response.consentDetails.consent != null && response.consentDetails.consent.Count > 0)
                {
                    var tracker = GlobalState.ActiveConsentRequests.FirstOrDefault(r => r.RequestId == requestId);
                    if (tracker != null)
                    {
                        var consentDetail = response.consentDetails.consent[0];
                        tracker.Status = consentDetail.status; // e.g., GRANTED
                        
                        if (consentDetail.consentArtefacts != null && consentDetail.consentArtefacts.Count > 0)
                        {
                            tracker.ConsentId = consentDetail.consentArtefacts[0].id;
                        }
                    }
                }
                else if (response?.errors != null && response.errors.Count > 0)
                {
                    MessageBox.Show("Gateway Error: " + response.errors[0].error.message, "Status Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (response != null && !string.IsNullOrEmpty(response.status))
                {
                    // Fallback for top-level status if details are pending
                    var tracker = GlobalState.ActiveConsentRequests.FirstOrDefault(r => r.RequestId == requestId);
                    if (tracker != null) tracker.Status = response.status;
                }
                
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking status: " + ex.Message);
            }
            finally
            {
                btnRefreshStatus.Enabled = true;
                btnRefreshStatus.Text = "REFRESH STATUS";
            }
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            if (dgvConsents.SelectedRows.Count == 0) return;

            string status = dgvConsents.SelectedRows[0].Cells["Status"].Value?.ToString();
            string consentId = dgvConsents.SelectedRows[0].Cells["ConsentId"].Value?.ToString();
            string patientName = dgvConsents.SelectedRows[0].Cells["PatientName"].Value?.ToString();

            if (status != "GRANTED" || string.IsNullOrEmpty(consentId))
            {
                MessageBox.Show("Please wait until consent is GRANTED to view records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var viewer = new HealthRecordViewerForm(consentId, patientName);
            viewer.ShowDialog();
        }

        private async void tmrLiveFeed_Tick(object sender, EventArgs e)
        {
            await UpdateLiveMonitor();
        }

        private async System.Threading.Tasks.Task UpdateLiveMonitor()
        {
            try
            {
                string json = await _abdmService.GetActivitiesAsync();
                var activities = JsonConvert.DeserializeObject<List<string>>(json);

                if (activities != null)
                {
                    lstActivities.BeginUpdate();
                    lstActivities.Items.Clear();
                    foreach (var activity in activities)
                    {
                        lstActivities.Items.Add(activity);
                    }
                    lstActivities.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Feed Error: " + ex.Message);
            }
        }
    }
}

