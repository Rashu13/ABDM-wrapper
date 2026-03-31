using ABDM_WinForms_Frontend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class PrescriptionForm : Form
    {
        private readonly string _abhaAddress;
        private readonly string _patientName;
        private readonly string _careContextReference;
        private readonly AbdmService _abdmService;

        public PrescriptionForm(string abhaAddress, string patientName, string careContextReference = "")
        {
            InitializeComponent();
            _abhaAddress = abhaAddress;
            _patientName = patientName;
            _careContextReference = careContextReference;
            _abdmService = new AbdmService();
            
            lblAbha.Text = $"ABHA: {_abhaAddress}";
            lblPatient.Text = $"Patient: {_patientName}";
        }

        private async void btnPushToAbdm_Click(object sender, EventArgs e)
        {
            try
            {
                btnPushToAbdm.Enabled = false;
                btnPushToAbdm.Text = "PUSHING...";

                var medicines = new List<object>();
                foreach (DataGridViewRow row in dgvMedicines.Rows)
                {
                    if (row.Cells[0].Value != null && !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                    {
                        medicines.Add(new
                        {
                            name = row.Cells[0].Value.ToString(),
                            dosage = row.Cells[1].Value?.ToString() ?? "1-0-1",
                            duration = row.Cells[2].Value?.ToString() ?? "5 days"
                        });
                    }
                }

                var prescription = new
                {
                    abhaAddress = _abhaAddress,
                    patientName = _patientName,
                    date = DateTime.Now.ToString("yyyy-MM-dd"),
                    careContextReference = _careContextReference,
                    medicines = medicines,
                    hipId = GlobalConfig.HipId
                };

                var response = await _abdmService.SavePrescriptionAsync(prescription);
                
                if (response.Contains("Successfully"))
                {
                    MessageBox.Show("✅ SUCCESS: Prescription Pushed to ABDM! \n\nThe patient can now see this in their ABHA App.", "ABDM Milestone M3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMedicines.Rows.Clear();
                    btnPushToAbdm.Text = "PUSHED SUCCESSFULLY";
                    btnPushToAbdm.BackColor = Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("Failed to push prescription: " + response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnPushToAbdm.Enabled = true;
                btnPushToAbdm.Text = "PUSH TO ABDM";
            }
        }
    }
}
