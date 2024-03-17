using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class TransactionReminderForm : Form
    {
        private System.Windows.Forms.TextBox textBoxUrl;

        public RReminder Reminder { get; private set; }
        public bool IsSnooze { get; private set; }

        public TransactionReminderForm(Customer customer)
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime dueDate = datePicker.Value;
            string description = txtDescription.Text;
            string priority = cmbPriority.SelectedItem?.ToString();
            string category = cmbCategory.SelectedItem?.ToString();


            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description for the reminder.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(priority))
            {
                MessageBox.Show("Please select a priority for the reminder.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a category for the reminder.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reminder = new RReminder
            {
                DueDate = dueDate,
                Description = description,
                Priority = priority,
                Category = category
            };

            DialogResult = DialogResult.OK;
            Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TransactionReminderForm_Load(object sender, EventArgs e)
        {
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
        }

        private void StartSnoozeTimer(TimeSpan snoozeDuration)
        {
            IsSnooze = true;
            Hide();


            Timer snoozeTimer = new Timer();
            snoozeTimer.Interval = (int)snoozeDuration.TotalMilliseconds;
            snoozeTimer.Tick += (sender, e) =>
            {
                snoozeTimer.Stop();
                IsSnooze = false;
                Show();
            };
            snoozeTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var snoozeDurationForm = new SnoozeDurationForm())
            {
                if (snoozeDurationForm.ShowDialog() == DialogResult.OK)
                {
                    StartSnoozeTimer(TimeSpan.FromMinutes(snoozeDurationForm.SnoozeDuration));
                }
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All Files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Reminder = new RReminder();

                foreach (string filePath in openFileDialog.FileNames)
                {
                    Reminder.AttachedFiles.Add(filePath);
                }


                listBoxAttachedFiles.Items.Clear();

                foreach (string filePath in Reminder.AttachedFiles)
                {
                    listBoxAttachedFiles.Items.Add(filePath);
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAttachedFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound Files (*.wav;*.mp3)|*.wav;*.mp3|All Files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                string selectedSoundFilePath = openFileDialog.FileName;

                MessageBox.Show($"Custom sound selected: {selectedSoundFilePath}", "Custom Sound Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var recurrencePatternForm = new RecurrencePatternForm())
            {
                if (recurrencePatternForm.ShowDialog() == DialogResult.OK)
                {
                    Reminder = new RReminder();

                    Reminder.RecurrencePattern = recurrencePatternForm.SelectedRecurrencePattern;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string url = Microsoft.VisualBasic.Interaction.InputBox("Enter URL:", "Add URL", "");

           
            if (!string.IsNullOrWhiteSpace(url))
            {
                
                listBoxAttachedUrls.Items.Add(url);
            }
        }
        private void listBoxAttachedUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
