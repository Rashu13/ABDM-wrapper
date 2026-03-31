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
        private readonly AbdmService _abdmService;

        public PrescriptionForm(string abhaAddress, string patientName)
        {
            InitializeComponent();
            _abhaAddress = abhaAddress;
            _patientName = patientName;
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
                    if (row.Cells[0].Value != null)
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
                    medicines = medicines,
                    hipId = GlobalConfig.HipId
                };

                var response = await _abdmService.SavePrescriptionAsync(prescription);
                
                if (response.Contains("Successfully"))
                {
                    MessageBox.Show("Prescription Pushed and FHIR Bundle Generated!", "ABDM Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
