using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace abdmWinforms
{
    public partial class LinkingHistoryForm : Form
    {
        private readonly AbdmService _abdmService;

        public LinkingHistoryForm()
        {
            InitializeComponent();
            _abdmService = new AbdmService();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Loading...";

                string json = await _abdmService.GetAllPatientsAsync(GlobalConfig.HipId);
                var patients = JsonConvert.DeserializeObject<List<PatientModel>>(json);

                if (patients != null)
                {
                    dgvHistory.DataSource = patients;
                    
                    // Cleanup Column Headers
                    if (dgvHistory.Columns["abhaAddress"] != null) dgvHistory.Columns["abhaAddress"].HeaderText = "ABHA Address";
                    if (dgvHistory.Columns["name"] != null) dgvHistory.Columns["name"].HeaderText = "Full Name";
                    if (dgvHistory.Columns["gender"] != null) dgvHistory.Columns["gender"].HeaderText = "Gender";
                    if (dgvHistory.Columns["dateOfBirth"] != null) dgvHistory.Columns["dateOfBirth"].HeaderText = "Birth Date";
                    if (dgvHistory.Columns["patientMobile"] != null) dgvHistory.Columns["patientMobile"].HeaderText = "Mobile";
                    
                    // Hide sensitive or unwanted columns
                    if (dgvHistory.Columns["patientReference"] != null) dgvHistory.Columns["patientReference"].Visible = false;
                    if (dgvHistory.Columns["patientDisplay"] != null) dgvHistory.Columns["patientDisplay"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs: " + ex.Message);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "REFRESH";
            }
        }
    }
}
