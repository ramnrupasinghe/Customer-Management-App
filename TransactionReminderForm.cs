using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class TransactionReminderForm : Form
    {
        public Reminder Reminder { get; private set; }

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
    }
}
