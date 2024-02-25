using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class AddReminderForm : Form
    {
        public Reminder Reminder { get; private set; }

        public AddReminderForm(Customer customer)
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            DateTime dueDate = datePickerDueDate.Value;
            Reminder = new Reminder { Description = description, DueDate = dueDate };

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
