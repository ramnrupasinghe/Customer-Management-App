using System;
using System.Collections.Generic;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using static CustomerManagementApp.CustomerDetailsForm;

namespace CustomerManagementApp
{
    public partial class ActivityCenterForm : Form
    {
        private List<ActivityLog> activityLogs;
        private List<ActivityLog> filteredLogs;

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

                    for (int i = 0; i < dgvActivityLogs.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvActivityLogs.Columns.Count; j++)
                        {
                            if (dgvActivityLogs.Rows[i].Cells[j].Value != null)
                            {
                                table.AddCell(new Phrase(dgvActivityLogs.Rows[i].Cells[j].Value.ToString()));
                            }
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

        private void PopulateActivityLogGrid(List<ActivityLog> logs)
        {
            dgvActivityLogs.Rows.Clear();
            foreach (ActivityLog log in logs)
            {
                dgvActivityLogs.Rows.Add(log.CustomerName, log.ActivityType, log.ActivityDateTime.ToString(), log.Details);
            }
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
            
            foreach (DataGridViewRow row in dgvActivityLogs.SelectedRows)
            {
                dgvActivityLogs.Rows.Remove(row);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Text = "Sort by Name";
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
    }
}
