using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomerManagementApp
{
    public partial class EditCustomerForm : Form
    {
        public EditCustomerForm()
        {
            InitializeComponent();

            InitializeControls();
        }

        private void InitializeControls()
        {
            lblPasswordStrength.Text = "";

            InitializeEmailAutocomplete();
            InitializeAddressAutocomplete();

        
            InitializeTagAutocomplete();

        
            txtEmail.Validating += TxtEmail_Validating;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtNotes.TextChanged += txtNotes_TextChanged;
            txtPhone.TextChanged += txtPhone_TextChanged;
        }

        private void InitializeEmailAutocomplete()
        {
            string[] previousEmails = { "jane@example.com", "john@example.com", "test@example.com" };
            txtEmail.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEmail.AutoCompleteCustomSource.AddRange(previousEmails);
        }

        private void InitializeAddressAutocomplete()
        {
            AutoCompleteStringCollection addresses = new AutoCompleteStringCollection();
            addresses.AddRange(new string[] { "456 Elm St", "123 Maple Ave", "789 Oak Rd", "321 Pine St" });
            txtAddress.AutoCompleteCustomSource = addresses;
            txtAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void InitializeTagAutocomplete()
        {
            string[] predefinedTags = { "VIP", "Regular", "Corporate", "New", "Special" };
            txtTags.AutoCompleteCustomSource.AddRange(predefinedTags);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            int score = CalculatePasswordStrength(password);

            if (score < 3)
            {
                lblPasswordStrength.Text = "Weak";
                lblPasswordStrength.ForeColor = System.Drawing.Color.Red;
            }
            else if (score < 6)
            {
                lblPasswordStrength.Text = "Medium";
                lblPasswordStrength.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                lblPasswordStrength.Text = "Strong";
                lblPasswordStrength.ForeColor = System.Drawing.Color.Green;
            }
        }

        private int CalculatePasswordStrength(string password)
        {
            int score = 0;

            score += password.Length;

            if (Regex.IsMatch(password, "[a-z]"))
                score += 1;

            if (Regex.IsMatch(password, "[A-Z]"))
                score += 2;

            if (Regex.IsMatch(password, "[0-9]"))
                score += 2;

            if (Regex.IsMatch(password, "[^a-zA-Z0-9]"))
                score += 3;

            return score;
        }
        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            txtEmail.Validating += TxtEmail_Validating;

            AutoCompleteStringCollection addresses = new AutoCompleteStringCollection();
            addresses.AddRange(new string[] { "456 Elm St", "123 Maple Ave", "789 Oak Rd", "321 Pine St" });
            txtAddress.AutoCompleteCustomSource = addresses;
            txtAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;


            txtEmail.TextChanged += txtEmail_TextChanged;

            string[] predefinedTags = { "VIP", "Regular", "Corporate", "New", "Special" };
            txtTags.AutoCompleteCustomSource.AddRange(predefinedTags);
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            txtPhone.Text = FormatPhoneNumber(phone);
            txtPhone.SelectionStart = txtPhone.Text.Length;
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            phoneNumber = Regex.Replace(phoneNumber, @"[^\d]", "");

            if (phoneNumber.Length >= 10)
            {
                return string.Format("{0:(###) ###-####}", long.Parse(phoneNumber));
            }
            else
            {
                return phoneNumber;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string[] previousEmails = { "jane@example.com", "john@example.com", "test@example.com" };

            string enteredText = txtEmail.Text.ToLower();
            var suggestions = previousEmails.Where(email => email.ToLower().StartsWith(enteredText));

            if (suggestions.Any())
            {
                string suggestedEmail = suggestions.First();
                if (suggestedEmail.Length > enteredText.Length)
                {
                    txtEmail.Text = suggestedEmail;
                    txtEmail.SelectionStart = enteredText.Length;
                    txtEmail.SelectionLength = suggestedEmail.Length - enteredText.Length;
                }
            }
        }
    }
}
