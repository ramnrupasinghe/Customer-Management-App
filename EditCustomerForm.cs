using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomerManagementApp
{
    public partial class EditCustomerForm : Form
    {
        public string CustomerDetails
        {
            get { return txtCustomerDetails.Text; }
            set { txtCustomerDetails.Text = value; }
        }

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

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
   
            txtEmail.Validating += TxtEmail_Validating;

            AutoCompleteStringCollection addresses = new AutoCompleteStringCollection();
            addresses.AddRange(new string[] { "456 Elm St", "123 Maple Ave", "789 Oak Rd", "321 Pine St" });
            txtAddress.AutoCompleteCustomSource = addresses;
            txtAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            string email = txtEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                e.Cancel = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                       + @"([-a-z0-9!\""#\$%&'\*\+/=\?^_`\{\|\}~]|(?<!\.)\.)*)(?<!\.)"
                       + @"([-a-z0-9!\""#\$%&'\*\+/=\?^_`\{\|\}~]|(?<!\.)\.)"
                       + @"[a-z0-9!\""#\$%&'\*\+/=\?^_`\{\|\}~]*(?<!\.)\.[a-z]{2,6}""?$";

            ; return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase); 
        }
    }
}
