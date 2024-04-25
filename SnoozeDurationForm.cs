﻿using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class SnoozeDurationForm : Form
    {
        public int SnoozeDuration { get; private set; }
        public string CustomLabel { get; private set; }
        public string PriorityLevel { get; private set; }
        public string SelectedSoundFilePath { get; private set; }
        public string RecurrencePattern { get; private set; }
        public string CustomMessage { get; private set; }

        public SnoozeDurationForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            if (value <= 0)
            {
                MessageBox.Show("Please enter a valid snooze duration.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string unit = comboBoxUnits.SelectedItem.ToString();
            string message;

            switch (unit)
            {
                case "Minutes":
                    SnoozeDuration = value;
                    message = $"Snooze duration set to {value} minutes.";
                    break;
                case "Hours":
                    SnoozeDuration = value * 60;
                    message = $"Snooze duration set to {value} hours.";
                    break;
                case "Days":
                    SnoozeDuration = value * 60 * 24;
                    message = $"Snooze duration set to {value} days.";
                    break;
                default:
                    message = "Invalid snooze duration unit selected.";
                    break;
            }

            CustomLabel = txtCustomLabel.Text;
            PriorityLevel = comboBoxPriority.SelectedItem.ToString();
            CustomMessage = txtCustomMessage.Text; 
            DialogResult = DialogResult.OK;
            Close();

            MessageBox.Show(message, "Snooze Duration Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SnoozeDuration = 0;
            CustomLabel = "";
            PriorityLevel = "";
            SelectedSoundFilePath = "";
            RecurrencePattern = "";
            CustomMessage = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            comboBoxUnits.SelectedIndex = 0;
        }

        private void SnoozeDurationForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            comboBoxUnits.SelectedIndex = 0;
        }
        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            comboBoxUnits.SelectedIndex = 0;

        }
        private void comboBoxUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            comboBoxUnits.SelectedIndex = 0;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            comboBoxUnits.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RecurrencePatternForm recurrencePatternForm = new RecurrencePatternForm();
            if (recurrencePatternForm.ShowDialog() == DialogResult.OK)
            {

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sound Files (*.wav;*.mp3)|*.wav;*.mp3|All Files (*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SelectedSoundFilePath = openFileDialog.FileName;
                MessageBox.Show($"Custom sound selected: {SelectedSoundFilePath}", "Custom Sound Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
