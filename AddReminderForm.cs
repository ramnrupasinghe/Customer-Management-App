using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class AddReminderForm : Form
    {
        public Reminder Reminder { get; private set; }
        private Customer customer;

        private const int MaxDescriptionLength = 100;

        public AddReminderForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblCustomerName.Text = $"Adding reminder for: {customer.Name}";
            datePickerDueDate.MinDate = DateTime.Today;

            cbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });
            cbCategory.Items.AddRange(new string[] { "Work", "Personal", "Shopping" });

           
            timePickerReminderTime.Value = DateTime.Now.AddHours(1);

            UpdateCharacterCounter();
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

            Reminder = new Reminder
            {
                Description = description,
                DueDate = datePickerDueDate.Value,
                AssociatedCustomer = customer,
                Priority = priority,
                Category = category,
                ReminderTime = timePickerReminderTime.Value 
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
    }
}
