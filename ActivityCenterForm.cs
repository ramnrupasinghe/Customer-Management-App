using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static CustomerManagementApp.CustomerDetailsForm;

namespace CustomerManagementApp
{
    public partial class ActivityCenterForm : Form
    {
        private List<ActivityLog> activityLogs;
        private List<ActivityLog> filteredLogs;
        private Stack<List<ActivityLog>> logHistory;

        public ActivityCenterForm(List<ActivityLog> activityLogs)
        {
            InitializeComponent();
            this.activityLogs = activityLogs;
            InitializeActivityLogGrid();
            PopulateActivityLogGrid();
            logHistory = new Stack<List<ActivityLog>>();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveActivityLogsToPdf();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveActivityLogsToPdf()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();

                    PdfPTable table = new PdfPTable(dgvActivityLogs.Columns.Count);
                    for (int i = 0; i < dgvActivityLogs.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(dgvActivityLogs.Columns[i].HeaderText));
                    }

                    table.HeaderRows = 1;

                    foreach (DataGridViewRow dgvRow in dgvActivityLogs.Rows)
                    {
                        foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                        {
                            table.AddCell(new Phrase(dgvCell.Value?.ToString() ?? ""));
                        }
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("Activity logs saved to PDF successfully!");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            filteredLogs = new List<ActivityLog>();

            foreach (ActivityLog log in activityLogs)
            {
                if (log.CustomerName.ToLower().Contains(searchText) ||
                    log.ActivityType.ToLower().Contains(searchText) ||
                    log.ActivityDateTime.ToString().ToLower().Contains(searchText) ||
                    log.Details.ToLower().Contains(searchText))
                {
                    filteredLogs.Add(log);
                }
            }

            PopulateActivityLogGrid(filteredLogs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sortingCriteria = button3.Tag.ToString();

            switch (sortingCriteria)
            {
                case "Name":
                    activityLogs = activityLogs.OrderBy(log => log.CustomerName).ToList();
                    break;
                case "ActivityType":
                    activityLogs = activityLogs.OrderBy(log => log.ActivityType).ToList();
                    break;
                case "ActivityDateTime":
                    activityLogs = activityLogs.OrderBy(log => log.ActivityDateTime).ToList();
                    break;
            }

            PopulateActivityLogGrid(activityLogs);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BulkDeleteActivityLogs();
        }

        private void chkFilterByDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Visible = chkFilterByDateRange.Checked;
            dateTimePickerEndDate.Visible = chkFilterByDateRange.Checked;
            lblStartDate.Visible = chkFilterByDateRange.Checked;
            lblEndDate.Visible = chkFilterByDateRange.Checked;

            if (!chkFilterByDateRange.Checked)
            {
                PopulateActivityLogGrid(activityLogs);
            }
        }

        private void btnSaveFilteredLogs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (chkFilterByDateRange.Checked)
                    {
                        DateTime startDate = dateTimePickerStartDate.Value;
                        DateTime endDate = dateTimePickerEndDate.Value;

                        filteredLogs = FilterLogsByDateRange(startDate, endDate);
                    }
                    else
                    {
                        filteredLogs = activityLogs;
                    }

                    SaveFilteredLogsToPdf(filteredLogs, filePath);
                }
            }
        }

        private void PopulateActivityLogGrid(List<ActivityLog> logs)
        {
            dgvActivityLogs.Rows.Clear();
            foreach (ActivityLog log in logs)
            {
                dgvActivityLogs.Rows.Add(log.CustomerName, log.ActivityType, log.ActivityDateTime.ToString(), log.Details);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Text = "Sort by Name";
            button3.Tag = "Name";
        }

        private void rbSortByEmail_CheckedChanged(object sender, EventArgs e)
        {
            button3.Text = "Sort by ActivityType";
            button3.Tag = "ActivityType";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button3.Text = "Sort by ActivityDateTime";
            button3.Tag = "ActivityDateTime";
        }

        private List<ActivityLog> FilterLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            return activityLogs.Where(log => log.ActivityDateTime >= startDate && log.ActivityDateTime <= endDate).ToList();
        }

        private void SaveFilteredLogsToPdf(List<ActivityLog> filteredLogs, string filePath)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dgvActivityLogs.Columns.Count);
            for (int i = 0; i < dgvActivityLogs.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dgvActivityLogs.Columns[i].HeaderText));
            }

            table.HeaderRows = 1;

            foreach (ActivityLog log in filteredLogs)
            {
                table.AddCell(new Phrase(log.CustomerName));
                table.AddCell(new Phrase(log.ActivityType));
                table.AddCell(new Phrase(log.ActivityDateTime.ToString()));
                table.AddCell(new Phrase(log.Details));
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("Filtered activity logs saved to PDF successfully!");
        }

        private void dgvActivityLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExportActivityLogsToTextFile();
        }

        private void ExportActivityLogsToTextFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (ActivityLog log in activityLogs)
                        {
                            writer.WriteLine($"{log.CustomerName},{log.ActivityType},{log.ActivityDateTime},{log.Details}");
                        }
                    }

                    MessageBox.Show("Activity logs exported to text file successfully!");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UndoLastAction();
        }

        private void UndoLastAction()
        {
            if (logHistory.Count > 0)
            {
                activityLogs = logHistory.Pop();
                PopulateActivityLogGrid(activityLogs);
            }
            else
            {
                MessageBox.Show("No actions to undo.");
            }
        }

        private void dgvActivityLogs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                logHistory.Push(new List<ActivityLog>(activityLogs));
                SendEmailNotification(activityLogs[e.RowIndex]);
            }
        }

        private void BulkDeleteActivityLogs()
        {
            if (dgvActivityLogs.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected activity logs?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvActivityLogs.SelectedRows)
                    {
                        activityLogs.RemoveAt(row.Index);
                        dgvActivityLogs.Rows.Remove(row);
                    }
                    MessageBox.Show("Selected activity logs deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("No activity logs selected for deletion.");
            }
        }

        private void SendEmailNotification(ActivityLog log)
        {
            try
            {
                var fromAddress = new MailAddress("your-email@example.com", "Activity Center");
                var toAddress = new MailAddress("recipient@example.com", "Recipient");
                const string fromPassword = "your-email-password";
                const string subject = "New Activity Log Added";
                string body = $"A new activity log has been added:\n\nCustomer Name: {log.CustomerName}\nActivity Type: {log.ActivityType}\nActivity Date/Time: {log.ActivityDateTime}\nDetails: {log.Details}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.example.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                MessageBox.Show("Email notification sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email notification: {ex.Message}");
            }
        }
    }
}
