using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class CustomerDetailsForm : Form
    {
        public CustomerDetailsForm(Customer customer)
        {
            InitializeComponent();
            DisplayCustomerDetails(customer);
        }

        private void DisplayCustomerDetails(Customer customer)
        {

            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
