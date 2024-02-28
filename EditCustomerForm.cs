using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class EditCustomerForm : Form
    {
        public string CustomerDetails { get; private set; }

        public EditCustomerForm()
        {
            InitializeComponent();

           
            txtName.Text = "Jane Smith";
            txtEmail.Text = "jane@example.com";
            txtPhone.Text = "9876543210";
            txtAddress.Text = "456 Elm St";
            txtCompanyName.Text = "XYZ Corp";
            txtNotes.Text = "VIP customer";
            txtTags.Text = "VIP";
        }

        public EditCustomerForm(string customerDetails) : this()
        {
            
            SetCustomerDetails(customerDetails);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            CustomerDetails = FormatCustomerDetails();

           
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SetCustomerDetails(string details)
        {
            
            string[] detailsArray = details.Split('\n');

           
            if (detailsArray.Length >= 7)
            {
                txtName.Text = detailsArray[0];
                txtEmail.Text = detailsArray[1];
                txtPhone.Text = detailsArray[2];
                txtAddress.Text = detailsArray[3];
                txtCompanyName.Text = detailsArray[4];
                txtNotes.Text = detailsArray[5];
                txtTags.Text = detailsArray[6];
            }
        }
        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            
        }
        private string FormatCustomerDetails()
        {
            
            return $"{txtName.Text}\n{txtEmail.Text}\n{txtPhone.Text}\n{txtAddress.Text}\n{txtCompanyName.Text}\n{txtNotes.Text}\n{txtTags.Text}";
        }
    }
}
