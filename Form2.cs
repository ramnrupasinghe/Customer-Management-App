using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class Form2 : Form
    {
        public Customer Customer { get; private set; }
        private Dictionary<string, Dictionary<string, string>> languageTranslations;

        public Form2()
        {
            InitializeComponent();
            InitializeLanguageTranslations();
        }

        public Form2(Customer customer) : this()
        {
            Customer = customer;
            LoadCustomerData(customer);
            InitializeLanguageTranslations();
        }
        private void LoadCustomerData(Customer customer)
        {
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtCompanyName.Text = customer.CompanyName;
            txtNotes.Text = customer.Notes;
        }
        private void InitializeLanguageTranslations()
        {
            languageTranslations = new Dictionary<string, Dictionary<string, string>>
{
    { "English", new Dictionary<string, string>
        {
            { "Name", "Name" },
            { "Email", "Email" },
            { "Phone", "Phone" },
            { "Address", "Address" },
            { "CompanyName", "Company Name" },
            { "Notes", "Notes" }
          
        }
    },
    { "Sinhala", new Dictionary<string, string>
        {
            { "Name", "නම" },
            { "Email", "ඊමේල්" },
            { "Phone", "දුරකථන අංකය" },
            { "Address", "ලිපිනය" },
            { "CompanyName", "මොගේ නම" },
            { "Notes", "සටහන්" }
        
        }
    },
    { "French", new Dictionary<string, string>
        {
            { "Name", "Nom" },
            { "Email", "Email" },
            { "Phone", "Téléphone" },
            { "Address", "Adresse" },
            { "CompanyName", "Nom de la société" },
            { "Notes", "Remarques" }
            
        }
    },
    { "Tamil", new Dictionary<string, string>
        {
            { "Name", "பெயர்" },
            { "Email", "மின்னஞ்சல்" },
            { "Phone", "தொலைபேசி" },
            { "Address", "முகவரி" },
            { "CompanyName", "கம்பனி பெயர்" },
            { "Notes", "குறிப்புகள்" }
            
        }
    }
};

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

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Please enter a company name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                CompanyName = txtCompanyName.Text,
                Notes = txtNotes.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^[0-9]+$");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCompanyName.Text = "";
            txtNotes.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = cbLanguage.SelectedItem?.ToString();

            if (selectedLanguage != null && languageTranslations.ContainsKey(selectedLanguage))
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox textBox)
                    {
                        string controlName = textBox.Name;
                        if (languageTranslations[selectedLanguage].ContainsKey(controlName))
                        {
                            textBox.Text = languageTranslations[selectedLanguage][controlName];
                        }
                    }
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            cbLanguage.Items.AddRange(new string[] { "English", "Sinhala", "French", "Tamil" });
        }
        private void button2_Click(object sender, EventArgs e)
        {

            string selectedLanguage = cbLanguage.SelectedItem?.ToString();

            if (selectedLanguage != null && languageTranslations.ContainsKey(selectedLanguage))
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox textBox)
                    {
                        string controlName = textBox.Name;
                        if (languageTranslations[selectedLanguage].ContainsKey(controlName))
                        {
                           
                            if (textBox.Text != languageTranslations[selectedLanguage][controlName])
                            {
                                textBox.Text = languageTranslations[selectedLanguage][controlName];
                            }
                        }
                    }
                }
            }
        }
    }
}
