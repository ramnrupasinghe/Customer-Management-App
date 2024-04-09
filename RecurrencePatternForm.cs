using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void button3_Click(object sender, EventArgs e)
        {
            RecurrenceExclusionsForm exclusionsForm = new RecurrenceExclusionsForm();
            if (exclusionsForm.ShowDialog() == DialogResult.OK)
            {
          
                List<DateTime> excludedDates = exclusionsForm.ExcludedDates;
              
                MessageBox.Show("Excluded dates: " + string.Join(", ", excludedDates), "Exclusions Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public enum RecurrencePattern
    {
        Daily,
        Weekly,
        Monthly
    }

    public class RecurrenceExclusionsForm : Form
    {
        private MonthCalendar monthCalendar;
        private Button addButton;
        private List<DateTime> excludedDates = new List<DateTime>();

        public List<DateTime> ExcludedDates => excludedDates;

        public RecurrenceExclusionsForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Recurrence Exclusions";
            this.Size = new Size(300, 300);

            monthCalendar = new MonthCalendar();
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Location = new Point(10, 10);
            monthCalendar.DateSelected += MonthCalendar_DateSelected;

            addButton = new Button();
            addButton.Text = "Add Exclusion";
            addButton.Location = new Point(30, 200);
            addButton.Click += AddButton_Click;

            this.Controls.Add(monthCalendar);
            this.Controls.Add(addButton);
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.SelectionRange = new SelectionRange(e.Start, e.End);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            excludedDates.Add(monthCalendar.SelectionStart);
            MessageBox.Show("Exclusion added successfully.", "Exclusion Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
