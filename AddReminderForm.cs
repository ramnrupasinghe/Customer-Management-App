using System;
using System.Windows.Forms;


namespace CustomerManagementApp
{
    public enum RecurrenceFrequency
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public partial class AddReminderForm : Form
    {
        public Reminder Reminder { get; private set; }
        private Customer customer;

        private const int MaxDescriptionLength = 100;

       
        private CheckBox chkRecurring;
        private ComboBox cbRecurrenceFrequency;
        private DateTimePicker datePickerEndDate;

        public AddReminderForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblCustomerName.Text = $"Adding reminder for: {customer.Name}";
            datePickerDueDate.MinDate = DateTime.Today;

            cbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });
            cbCategory.Items.AddRange(new string[] { "Work", "Personal", "Shopping" });

            timePickerReminderTime.Value = DateTime.Now.AddHours(1);

           
            chkRecurring = new CheckBox();
            chkRecurring.Text = "Recurring";
            chkRecurring.AutoSize = true;
            chkRecurring.Location = new System.Drawing.Point(20, 220);
            chkRecurring.CheckedChanged += ChkRecurring_CheckedChanged;
            Controls.Add(chkRecurring);

            cbRecurrenceFrequency = new ComboBox();
            cbRecurrenceFrequency.Items.AddRange(new string[] { "Daily", "Weekly", "Monthly", "Yearly" });
            cbRecurrenceFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRecurrenceFrequency.Location = new System.Drawing.Point(150, 220);
            cbRecurrenceFrequency.Enabled = false;
            Controls.Add(cbRecurrenceFrequency);

            datePickerEndDate = new DateTimePicker();
            datePickerEndDate.Location = new System.Drawing.Point(20, 250);
            datePickerEndDate.Enabled = false;
            Controls.Add(datePickerEndDate);
        }

        private void ChkRecurring_CheckedChanged(object sender, EventArgs e)
        {
           
            cbRecurrenceFrequency.Enabled = chkRecurring.Checked;
            datePickerEndDate.Enabled = chkRecurring.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (description.Length > MaxDescriptionLength)
            {
                MessageBox.Show($"Description length cannot exceed {MaxDescriptionLength} characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string priority = cbPriority.SelectedItem.ToString();
            string category = cbCategory.SelectedItem.ToString();

           
            bool isRecurring = chkRecurring.Checked;
            RecurrenceFrequency recurrenceFrequency = RecurrenceFrequency.None;
            DateTime? endDate = null;

            if (isRecurring)
            {
             
                if (cbRecurrenceFrequency.SelectedItem == null)
                {
                    MessageBox.Show("Please select a recurrence frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Enum.TryParse(cbRecurrenceFrequency.SelectedItem.ToString(), out recurrenceFrequency);
                }

                
                endDate = datePickerEndDate.Value;
            }

           
            Reminder = new Reminder
            {
                Description = description,
                DueDate = datePickerDueDate.Value,
                AssociatedCustomer = customer,
                Priority = priority,
                Category = category,
                ReminderTime = timePickerReminderTime.Value,
                
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateCharacterCounter();
        }

        private void UpdateCharacterCounter()
        {
            int remainingCharacters = MaxDescriptionLength - txtDescription.TextLength;
            lblCharacterCounter.Text = $"{remainingCharacters} characters remaining";
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timePickerReminderTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddReminderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
