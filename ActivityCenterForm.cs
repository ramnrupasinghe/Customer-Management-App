using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CustomerManagementApp.CustomerDetailsForm;

namespace CustomerManagementApp
{
    public partial class ActivityCenterForm : Form
    {
        private List<ActivityLog> activityLogs;

        public ActivityCenterForm(List<ActivityLog> activityLogs)
        {
            InitializeComponent();
            this.activityLogs = activityLogs;
            InitializeActivityLogGrid(); 
            PopulateActivityLogGrid();
        }

        private void InitializeActivityLogGrid()
        {
            dgvActivityLogs.Columns.Add("CustomerName", "Customer Name");
            dgvActivityLogs.Columns.Add("ActivityType", "Activity Type");
            dgvActivityLogs.Columns.Add("ActivityDateTime", "Activity Date/Time");
            dgvActivityLogs.Columns.Add("Details", "Details");
        }

        private void PopulateActivityLogGrid()
        {
            dgvActivityLogs.Rows.Clear();
            foreach (ActivityLog log in activityLogs)
            {
                dgvActivityLogs.Rows.Add(log.CustomerName, log.ActivityType, log.ActivityDateTime.ToString(), log.Details);
            }
        }

        private void dgvActivityLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }
    }
}