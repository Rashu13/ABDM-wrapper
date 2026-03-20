using ABDM_WinForms_Frontend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace abdmWinforms
{
    public partial class PrescriptionForm : Form
    {
        private readonly AbdmService _abdmService;
        private readonly string _abhaAddress;

        public PrescriptionForm(string abhaAddress, string patientName)
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            _abhaAddress = abhaAddress;

            lblPatientName.Text = patientName;
            lblPatientAbha.Text = abhaAddress;
        }

        private async void btnSaveAndSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveAndSend.Enabled = false;
                btnSaveAndSend.Text = "LINKING...";

                // Collect medicines from the Grid
                var medicinesList = new List<MedicineModel>();
                foreach (DataGridViewRow row in dgvMedicines.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        medicinesList.Add(new MedicineModel
                        {
                            name = row.Cells[0].Value.ToString(),
                            dosage = row.Cells[1].Value?.ToString() ?? "as directed",
                            duration = row.Cells[2].Value?.ToString() ?? "-"
                        });
                    }
                }

                if (medicinesList.Count == 0)
                {
                    MessageBox.Show("Please add at least one medicine.");
                    return;
                }

                // Prepare Prescription Object
                var prescription = new PrescriptionModel
                {
                    abhaAddress = _abhaAddress,
                    patientName = lblPatientName.Text,
                    date = DateTime.Now.ToString("yyyy-MM-dd"),
                    medicines = medicinesList,
                    hipId = GlobalConfig.HipName
                };

                // Push to Backend for storage & FHIR conversion
                string response = await _abdmService.SavePrescriptionAsync(prescription);

                MessageBox.Show(response, "ABDM M3 Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save: " + ex.Message);
            }
            finally
            {
                btnSaveAndSend.Enabled = true;
                btnSaveAndSend.Text = "SAVE & PUSH TO ABDM";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontSubTitle = new Font("Arial", 12, FontStyle.Bold);
            Font fontBody = new Font("Arial", 10);

            float y = 50;
            g.DrawString(GlobalConfig.HipName, fontTitle, Brushes.Black, 50, y); y += 30;
            g.DrawString("PRESCRIPTION", fontSubTitle, Brushes.Gray, 50, y); y += 40;

            g.DrawString("Patient: " + lblPatientName.Text, fontBody, Brushes.Black, 50, y); y += 20;
            g.DrawString("ABHA: " + lblPatientAbha.Text, fontBody, Brushes.Black, 50, y); y += 20;
            g.DrawString("Date: " + DateTime.Now.ToShortDateString(), fontBody, Brushes.Black, 50, y); y += 40;

            g.DrawString("Medicines:", fontSubTitle, Brushes.Black, 50, y); y += 30;

            foreach (DataGridViewRow row in dgvMedicines.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string line = "- " + row.Cells[0].Value.ToString() + " (" + row.Cells[1].Value?.ToString() + ") for " + row.Cells[2].Value?.ToString();
                    g.DrawString(line, fontBody, Brushes.Black, 70, y); y += 20;
                }
            }

            y += 50;
            g.DrawString("Signature: ________________", fontBody, Brushes.Black, 500, y);
        }
    }
}
