using ABDM_WinForms_Frontend;
using System;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class SmsInviteForm : Form
    {
        private readonly AbdmService _abdmService;

        public SmsInviteForm()
        {
            InitializeComponent();
            _abdmService = new AbdmService();
        }

        private async void btnSendInvite_Click(object sender, EventArgs e)
        {
            string mobile = txtMobile.Text.Trim();
            if (mobile.Length != 10)
            {
                MessageBox.Show("Please enter a valid 10-digit mobile number.", "Input Error");
                return;
            }

            try
            {
                btnSendInvite.Enabled = false;
                btnSendInvite.Text = "SENDING...";

                btnSendInvite.Text = "SENDING...";

                // Fix: Calling the service with simple parameters as defined in AbdmService.cs
                // Signature: SendSmsNotifyAsync(string abhaAddress, string mobile, string hipId)
                string response = await _abdmService.SendSmsNotifyAsync("", mobile, GlobalConfig.HipId);

                MessageBox.Show("SMS Invitation Sent Successfully!\n\nPatient will receive a link to join your facility.", "ABDM Invite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send SMS: " + ex.Message, "Error");
            }
            finally
            {
                btnSendInvite.Enabled = true;
                btnSendInvite.Text = "SEND JOINING LINK";
            }
        }
    }
}
