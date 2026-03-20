using ABDM_WinForms_Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            // Initial poll
            UpdateLiveMonitor();
        }

        private async void tmrLiveFeed_Tick(object sender, EventArgs e)
        {
            await UpdateLiveMonitor();
        }

        private async System.Threading.Tasks.Task UpdateLiveMonitor()
        {
            try
            {
                // Fetch live activities from backend
                string json = await _abdmService.GetActivitiesAsync();
                var activities = JsonConvert.DeserializeObject<List<string>>(json);

                if (activities != null)
                {
                    // To avoid UI flickering, only update if count changed or for simplicity, clear and refill
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
                // Silence errors during polling to avoid annoying popups
                Console.WriteLine("Feed Error: " + ex.Message);
            }
        }
    }
}
