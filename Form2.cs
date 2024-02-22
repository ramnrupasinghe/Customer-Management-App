using System;
using System.Windows.Forms;
using System.Xml.Linq;

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
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}