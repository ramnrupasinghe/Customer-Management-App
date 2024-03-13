using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class TransactionReminderForm : Form
    {
        public Reminder Reminder { get; private set; }
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

            Reminder = new Reminder
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
    }
}
