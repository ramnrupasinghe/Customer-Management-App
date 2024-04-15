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
        private void PrintPreviewForm_Load(object sender, EventArgs e)
        {
        
        }
        private void PrintPageEventHandler(object sender, PrintPageEventArgs e)
        {
          
            float startX = 50; 
            float startY = 50; 
            float lineHeight = 20; 

          
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

          
            string[] columnHeaders = { "Customer Name", "Activity Type", "Activity Date/Time", "Details" };
            float currentX = startX;
            foreach (string header in columnHeaders)
            {
                e.Graphics.DrawString(header, font, brush, currentX, startY);
                currentX += 150; 
            }

        
            float currentY = startY + lineHeight; 
            foreach (ActivityLog log in activityLogs)
            {
                e.Graphics.DrawString(log.CustomerName, font, brush, startX, currentY);
                e.Graphics.DrawString(log.ActivityType, font, brush, startX + 150, currentY);
                e.Graphics.DrawString(log.ActivityDateTime.ToString(), font, brush, startX + 300, currentY);
                e.Graphics.DrawString(log.Details, font, brush, startX + 450, currentY);

                currentY += lineHeight; 
            }
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
