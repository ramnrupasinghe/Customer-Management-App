using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class CustomerDetailsForm : Form
    {
        private Customer customer;

        public CustomerDetailsForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            DisplayCustomerDetails(customer);
        }

        private void DisplayCustomerDetails(Customer customer)
        {
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtCompanyName.Text = customer.CompanyName;
            txtNotes.Text = customer.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            customer.Name = txtName.Text;
            customer.Email = txtEmail.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.CompanyName = txtCompanyName.Text;
            customer.Notes = txtNotes.Text;
            MessageBox.Show("Changes saved successfully!");
        }
     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayCustomerDetails(customer);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
