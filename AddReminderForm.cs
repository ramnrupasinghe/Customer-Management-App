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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();

            if (description.Length > MaxDescriptionLength)
            {
                MessageBox.Show($"Description length cannot exceed {MaxDescriptionLength} characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (datePickerDueDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Due date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string priority = cbPriority.SelectedItem?.ToString();
            string category = cbCategory.SelectedItem?.ToString();

            
            Reminder = new Reminder
            {
                Description = description,
                DueDate = datePickerDueDate.Value,
                AssociatedCustomer = customer,
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

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPriority = cbPriority.SelectedItem?.ToString();
            MessageBox.Show($"Priority selected: {selectedPriority}", "Priority Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem?.ToString();
            MessageBox.Show($"Category selected: {selectedCategory}", "Category Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
