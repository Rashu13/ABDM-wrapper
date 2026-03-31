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
        private readonly string _abhaAddress;
        private readonly string _patientName;
        private readonly AbdmService _abdmService;
        private Timer _pollTimer;
        private int _pollTicks = 0;
        private bool _isProcessing = false;

        public LinkingStatusPollForm(string requestId, string abhaAddress = "", string patientName = "")
        {
            InitializeComponent();
            _requestId = requestId;
            _abhaAddress = abhaAddress;
            _patientName = patientName;
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
                
                var response = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                string status = response?.status?.ToString();

                UpdateUIBasedOnStatus(status);

                if (string.IsNullOrEmpty(status)) return;

                bool isSuccess = status.ToUpper().Contains("LINKED") || 
                                status.ToUpper().Contains("SUCCESS") || 
                                status.ToUpper().Contains("COMPLETED");

                if (isSuccess)
                {
                    _pollTimer.Stop();
                    var diagResult = MessageBox.Show("Records linked successfully! Do you want to write a prescription now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                    if (diagResult == DialogResult.Yes)
                    {
                        using (var prescriptionForm = new PrescriptionForm(_abhaAddress, _patientName))
                        {
                            prescriptionForm.ShowDialog(this);
                        }
                    }
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (status.ToUpper().Contains("ERROR") || status.ToUpper().Contains("FAILED"))
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
                if (_pollTicks > 40)
                {
                    _pollTimer.Stop();
                    MessageBox.Show("Request timeout. Please check your internet or the ABHA app.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        private void UpdateUIBasedOnStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                lblCurrentStep.Text = "WAITING...";
                return;
            }

            lblCurrentStep.Text = status.Replace("_", " ");
            
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
