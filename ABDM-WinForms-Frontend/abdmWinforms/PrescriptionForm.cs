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
        private readonly List<CareContext> _careContexts;

        private readonly string _patientReference;
        private readonly string _gender;
        private readonly string _birthDate;
        private readonly AbdmService _abdmService;

        public PrescriptionForm(string abhaAddress, string patientName, List<CareContext> careContexts, string patientReference = "", string gender = "", string dob = "")
        {
            InitializeComponent();
            _abhaAddress = abhaAddress;
            _patientName = patientName;
            _careContexts = careContexts ?? new List<CareContext>();
            _patientReference = patientReference;
            _gender = gender;
            _birthDate = dob;
            _abdmService = new AbdmService();
            
            lblAbha.Text = string.Format("ABHA: {0}", _abhaAddress);
            lblPatient.Text = string.Format("Patient: {0}", _patientName);

            // Populate Care Contexts Dropdown
            cmbCareContext.Items.Clear();
            foreach (var ctx in _careContexts)
            {
                cmbCareContext.Items.Add(string.Format("{0} ({1})", ctx.referenceNumber, ctx.display));
            }

            if (cmbCareContext.Items.Count > 0)
            {
                cmbCareContext.SelectedIndex = 0;
                lblStatus.Text = "✅ Ready to push to selected Visit ID.";
                lblStatus.ForeColor = Color.SeaGreen;
            }
            else
            {
                lblStatus.Text = "⚠️ WARNING: No Linked Care Context found.";
                lblStatus.ForeColor = Color.OrangeRed;
            }

            cmbHiType.SelectedIndex = 0; // Default to Prescription
        }

        private async void btnPushToAbdm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCareContext.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a Visit ID (Care Context) to push data.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnPushToAbdm.Enabled = false;
                btnPushToAbdm.Text = "PUSHING...";

                string selectedRef = _careContexts[cmbCareContext.SelectedIndex].referenceNumber;

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
                    gender = _gender,
                    birthDate = _birthDate,
                    careContextReference = selectedRef,
                    patientReference = _patientReference,
                    medicines = medicines,
                    hipId = GlobalConfig.HipId,
                    hiType = cmbHiType.SelectedItem.ToString()
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
