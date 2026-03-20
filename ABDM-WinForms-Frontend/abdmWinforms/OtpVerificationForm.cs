using ABDM_WinForms_Frontend;
using System;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class OtpVerificationForm : Form
    {
        private readonly string _requestId;
        private readonly string _linkRefNumber;
        private readonly AbdmService _abdmService;

        public OtpVerificationForm(string requestId, string linkRefNumber)
        {
            InitializeComponent();
            _requestId = requestId;
            _linkRefNumber = linkRefNumber;
            _abdmService = new AbdmService();
        }

        private async void btnConfirmLink_Click(object sender, EventArgs e)
        {
            if (txtOtp.Text.Length != 6)
            {
                MessageBox.Show("Please enter a valid 6-digit OTP.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnConfirmLink.Enabled = false;
                btnConfirmLink.Text = "LINKING...";

                // Call the Confirm Link API with the mandatory linkRefNumber (PDF Nov 2024)
                string response = await _abdmService.ConfirmLinkAsync(_requestId, txtOtp.Text, _linkRefNumber);

                MessageBox.Show("Patient Records Linked Successfully!\n\nDetails: " + response, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Linking Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConfirmLink.Enabled = true;
                btnConfirmLink.Text = "LINK ACCOUNT";
            }
        }
    }
}
