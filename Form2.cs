using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class Form2 : Form
    {
        public Customer Customer { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Customer customer) : this()
        {
            Customer = customer;
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address; // Populate address field
            txtCompanyName.Text = customer.CompanyName; // Populate company name field
            txtNotes.Text = customer.Notes; // Populate notes field
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("Please enter a valid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text, // Retrieve address field data
                CompanyName = txtCompanyName.Text, // Retrieve company name field data
                Notes = txtNotes.Text // Retrieve notes field data
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidEmail(string email)
        {
            // Simple email validation using regular expression
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phone)
        {
            // Simple phone number validation allowing only numeric characters
            return Regex.IsMatch(phone, @"^[0-9]+$");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // This method is required to handle the Load event of the form
            // Add your code here if you need to perform any actions when the form is loaded
        }
    }
}
