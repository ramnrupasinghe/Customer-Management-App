using System;
using System.Windows.Forms;
using System.Drawing;

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

        private void button2_Click(object sender, EventArgs e)
        {
            
            RecurrencePatternHelpForm helpForm = new RecurrencePatternHelpForm();

            helpForm.BackColor = Color.White;

            helpForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButtonDaily.Checked = false;
            radioButtonWeekly.Checked = false;
            radioButtonMonthly.Checked = false;

           
            SelectedRecurrencePattern = RecurrencePattern.Daily; 

            MessageBox.Show("Form reset successfully.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public enum RecurrencePattern
    {
        Daily,
        Weekly,
        Monthly
    }

}
