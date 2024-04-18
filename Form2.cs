using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace CustomerManagementApp
{
    public partial class Form2 : Form
    {
        public Customer Customer { get; private set; }
        private Dictionary<string, Dictionary<string, string>> languageTranslations;
        private bool isFormLoaded = false;
        private bool isEmailMasked = false;
        private Dictionary<string, string> validationMessages;

        public Form2()
        {
            InitializeComponent();
            InitializeLanguageTranslations();
            LoadValidationMessages();
            AttachValidationEvents();
        }

        public Form2(Customer customer) : this()
        {
            Customer = customer;
            LoadCustomerData(customer);
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

        private void LoadValidationMessages()
        {
            string validationMessagesFile = "validation_messages.json";
            if (File.Exists(validationMessagesFile))
            {
                string json = File.ReadAllText(validationMessagesFile);
                validationMessages = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                validationMessages = new Dictionary<string, string>
                {
                    { "Name", "Please enter a valid name." },
                    { "Email", "Please enter a valid email address." },
                    { "Phone", "Please enter a valid phone number." },
                    { "Address", "Please enter a valid address." },
                    { "CompanyName", "Please enter a valid company name." }
                };
                SaveValidationMessages();
            }
        }

        private void SaveValidationMessages()
        {
            string validationMessagesFile = "validation_messages.json";
            string json = JsonConvert.SerializeObject(validationMessages);
            File.WriteAllText(validationMessagesFile, json);
        }

        private void AttachValidationEvents()
        {
            txtName.Validating += TxtName_Validating;
            txtEmail.Validating += TxtEmail_Validating;
            txtPhone.Validating += TxtPhone_Validating;
            txtAddress.Validating += TxtAddress_Validating;
            txtCompanyName.Validating += TxtCompanyName_Validating;
        }

        private void TxtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                MessageBox.Show(validationMessages["Name"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                MessageBox.Show(validationMessages["Email"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                e.Cancel = true;
                MessageBox.Show(validationMessages["Phone"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                MessageBox.Show(validationMessages["Address"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCompanyName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                e.Cancel = true;
                MessageBox.Show(validationMessages["CompanyName"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
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

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoaded)
            {
                UpdateLanguageTranslation();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbLanguage.Items.AddRange(new string[] { "English", "Sinhala", "French", "Tamil" });
            isFormLoaded = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isFormLoaded)
            {
                UpdateLanguageTranslation();
            }
        }
        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void UpdateLanguageTranslation()
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
