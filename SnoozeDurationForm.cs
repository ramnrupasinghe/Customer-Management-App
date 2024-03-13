using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class SnoozeDurationForm : Form
    {
        public int SnoozeDuration { get; private set; }

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

            DialogResult = DialogResult.OK;
            Close();

            MessageBox.Show(message, "Snooze Duration Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            SnoozeDuration = 0;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SnoozeDurationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            numericUpDown1.Value = 0;

           
            comboBoxUnits.SelectedIndex = 0;
        }
    }
}
