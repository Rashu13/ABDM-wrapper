using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class LinkingStatusPollForm : Form
    {
        private readonly string _requestId;
        private readonly AbdmService _abdmService;
        private Timer _pollTimer;
        private int _pollTicks = 0;
        private bool _isProcessing = false;

        public LinkingStatusPollForm(string requestId)
        {
            InitializeComponent();
            _requestId = requestId;
            _abdmService = new AbdmService();
            SetupTimer();
        }

        private void SetupTimer()
        {
            _pollTimer = new Timer();
            _pollTimer.Interval = 3000; // 3 seconds
            _pollTimer.Tick += PollTimer_Tick;
        }

        private void LinkingStatusPollForm_Load(object sender, EventArgs e)
        {
            lblRequestId.Text = $"Req ID: {_requestId}";
            _pollTimer.Start();
        }

        private async void PollTimer_Tick(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;
            _pollTicks++;

            try
            {
                lblStatus.Text = $"Checking status... (Attempt {_pollTicks})";
                string jsonResponse = await _abdmService.GetLinkStatusAsync(_requestId);
                
                // Status mapping based on Wrapper logs
                // Expecting structure like: {"requestId":"...","status":"AUTH_CONFIRM_ACCEPTED", "error":null}
                var response = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                string status = (string)response.status;

                UpdateUIBasedOnStatus(status);

                if (status == "CARE_CONTEXT_LINKED" || status == "COMPLETED" || status == "SUCCESS")
                {
                    _pollTimer.Stop();
                    MessageBox.Show("Records linked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (status.Contains("ERROR") || status.Contains("FAILED"))
                {
                    _pollTimer.Stop();
                    MessageBox.Show($"Linking failed: {status}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error polling status. Retrying...";
            }
            finally
            {
                _isProcessing = false;
                if (_pollTicks > 40) // Timeout after ~2 mins
                {
                    _pollTimer.Stop();
                    MessageBox.Show("Request timeout. Please check your internet or the ABHA app.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void UpdateUIBasedOnStatus(string status)
        {
            lblCurrentStep.Text = status.Replace("_", " ");
            
            // Rich Micro-interaction: Change color based on step
            if (status.Contains("ACCEPTED")) lblCurrentStep.ForeColor = Color.SkyBlue;
            else if (status.Contains("GENERATED")) lblCurrentStep.ForeColor = Color.Gold;
            else if (status.Contains("LINKED")) lblCurrentStep.ForeColor = Color.LimeGreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _pollTimer.Stop();
            this.Close();
        }
    }
}
