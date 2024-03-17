using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class RecurrencePatternForm : Form
    {
        public RecurrencePattern SelectedRecurrencePattern { get; private set; }

        public RecurrencePatternForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioButtonDaily.Checked)
            {
                SelectedRecurrencePattern = RecurrencePattern.Daily;
            }
            else if (radioButtonWeekly.Checked)
            {
                SelectedRecurrencePattern = RecurrencePattern.Weekly;
            }
            else if (radioButtonMonthly.Checked)
            {
                SelectedRecurrencePattern = RecurrencePattern.Monthly;
            }
            else
            {

                MessageBox.Show("Please select a recurrence pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult = DialogResult.OK;
            Close();
            MessageBox.Show("Recurrence pattern selected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void groupBoxRecurrencePattern_Enter(object sender, EventArgs e)
        {

        }
    }

    public enum RecurrencePattern
    {
        Daily,
        Weekly,
        Monthly
    }

}
