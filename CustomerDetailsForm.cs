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
            txtAddress.Text = customer.Address; // Populate address field
            txtCompanyName.Text = customer.CompanyName; // Populate company name field
            txtNotes.Text = customer.Notes;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}