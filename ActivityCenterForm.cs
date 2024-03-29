﻿using System;
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
            foreach (DataGridViewRow row in dgvActivityLogs.SelectedRows)
            {
                dgvActivityLogs.Rows.Remove(row);
            }
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
    }
}
