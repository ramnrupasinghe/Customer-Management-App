using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using CustomerManagementApp; 
using static CustomerManagementApp.CustomerDetailsForm;

namespace CustomerManagementApp
{
    public partial class PrintPreviewForm : Form
    {
        private List<ActivityLog> activityLogs;

        public PrintPreviewForm()
        {
            InitializeComponent();
        }

        public void LoadActivityLogs(List<ActivityLog> logs)
        {
            activityLogs = logs;
            PopulateActivityLogGrid();
        }

        private void PopulateActivityLogGrid()
        {
            dgvActivityLogs.Rows.Clear();
            foreach (ActivityLog log in activityLogs)
            {
                dgvActivityLogs.Rows.Add(log.CustomerName, log.ActivityType, log.ActivityDateTime.ToString(), log.Details);
            }
        }
        private void PrintPreviewForm_Load(object sender, EventArgs e)
        {
            
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += new PrintPageEventHandler(PrintPageEventHandler);

           
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                
                pd.Print();
            }
        }
        private void PrintPageEventHandler(object sender, PrintPageEventArgs e)
        {
            string text = "Hello, World!";
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            float x = 100; 
            float y = 100; 
            e.Graphics.DrawString(text, font, brush, x, y);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvActivityLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
