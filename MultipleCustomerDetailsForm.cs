using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography; 
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace CustomerManagementApp
{
    public partial class MultipleCustomerDetailsForm : Form
    {
        private Panel[] deletedPanels;
        private Button btnEdit;
        private Button btnImport;
        private Button btnSort;
        private Button btnIntegrateWithCRM;
        private Button btnExportToPDF; 
        private TextBox txtSearch;
        private ComboBox cmbSortOptions;

        public MultipleCustomerDetailsForm()
        {
            InitializeComponent();
            deletedPanels = null;
            InitializeEditButton();
            InitializeImportButton();
            InitializeSearchTextBox();
            InitializeSortButton();
            InitializeSortComboBox();
            InitializeCRMIntegrationButton();
            InitializeExportToPDFButton(); 
            InitializeRealTimeCollaboration(); 
            InitializePaymentGatewayIntegration(); 
        }

        private void InitializeSortComboBox()
        {
            cmbSortOptions = new ComboBox();
            cmbSortOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortOptions.Items.AddRange(new object[] { "Name", "Email", "Phone" });
            cmbSortOptions.SelectedIndex = 0;
            cmbSortOptions.Location = new Point(10, 330);
            cmbSortOptions.Size = new Size(150, 23);
            cmbSortOptions.SelectedIndexChanged += cmbSortOptions_SelectedIndexChanged;
            this.Controls.Add(cmbSortOptions);
        }

        private void InitializeEditButton()
        {
            btnEdit = new Button();
            btnEdit.Text = "Search";
            btnEdit.Location = new Point(225, 297);
            btnEdit.Click += button1_Click_1;
            this.Controls.Add(btnEdit);
        }

        private void InitializeImportButton()
        {
            btnImport = new Button();
            btnImport.Text = "Import";
            btnImport.Location = new Point(320, 297);
            btnImport.Click += btnImport_Click;
            this.Controls.Add(btnImport);
        }

        private void InitializeSearchTextBox()
        {
            txtSearch = new TextBox();
            txtSearch.Text = "Search by name...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Location = new Point(10, 297);
            txtSearch.Size = new Size(200, 23);
            this.Controls.Add(txtSearch);
        }

        private void InitializeSortButton()
        {
            btnSort = new Button();
            btnSort.Text = "Sort";
            btnSort.Location = new Point(170, 330);
            this.Controls.Add(btnSort);
        }

        private void InitializeCRMIntegrationButton()
        {
            btnIntegrateWithCRM = new Button();
            btnIntegrateWithCRM.Text = "Integrate with CRM";
            btnIntegrateWithCRM.Location = new Point(415, 297);
            btnIntegrateWithCRM.Click += btnIntegrateWithCRM_Click;
            this.Controls.Add(btnIntegrateWithCRM);
        }

        private void InitializeExportToPDFButton() 
        {
            btnExportToPDF = new Button();
            btnExportToPDF.Text = "Export to PDF";
            btnExportToPDF.Location = new Point(510, 297);
            btnExportToPDF.Click += btnExportToPDF_Click;
            this.Controls.Add(btnExportToPDF);
        }

        private void InitializeRealTimeCollaboration() 
        {
            
        }

        private void InitializePaymentGatewayIntegration() 
        {
           
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by name...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void cmbSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbSortOptions = (ComboBox)sender;
            string selectedOption = cmbSortOptions.SelectedItem.ToString();

            SortCustomerDetailsByCriterion(selectedOption);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        string customerDetail = textBox.Text.ToLower();
                        if (customerDetail.Contains(searchText))
                            control.Visible = true;
                        else
                            control.Visible = false;
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Customer Details";
            saveFileDialog.FileName = "customer_details.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is Panel && control.Name == "dynamicPanel")
                            {
                                foreach (Control innerControl in control.Controls)
                                {
                                    if (innerControl is TextBox)
                                    {
                                        writer.WriteLine(((TextBox)innerControl).Text);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while saving details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnIntegrateWithCRM_Click(object sender, EventArgs e)
        {
            bool isValidData = await ValidateCustomerData();
            if (isValidData)
            {
                await IntegrateWithCRMAsync();
            }
            else
            {
                MessageBox.Show("Please ensure all customer details are valid before integrating with CRM.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> ValidateCustomerData()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        string[] customerInfo = textBox.Text.Split('\n');
                        string customerEmail = customerInfo[1];
                        string customerPhone = customerInfo[2];

                        bool isValidEmail = await ValidateEmail(customerEmail);
                        bool isValidPhone = await ValidatePhoneNumber(customerPhone);

                        if (!isValidEmail)
                        {
                            MessageBox.Show($"Invalid email format: {customerEmail}", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (!isValidPhone)
                        {
                            MessageBox.Show($"Invalid phone number format: {customerPhone}", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private async Task<bool> ValidateEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return await Task.Run(() => Regex.IsMatch(email, emailPattern));
        }

        private async Task<bool> ValidatePhoneNumber(string phoneNumber)
        {

            string phonePattern = @"^\d{10}$";
            return await Task.Run(() => Regex.IsMatch(phoneNumber, phonePattern));
        }

        private async Task IntegrateWithCRMAsync()
        {
            string crmBaseUrl = "YOUR_CRM_BASE_URL";
            string accessToken = "YOUR_ACCESS_TOKEN";

            string createLeadEndpoint = $"{crmBaseUrl}/services/data/v52.0/sobjects/Lead/";

            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        string[] customerInfo = textBox.Text.Split('\n');
                        string customerName = customerInfo[0];
                        string customerEmail = customerInfo[1];
                        string customerPhone = customerInfo[2];

                        var leadData = new
                        {
                            LastName = customerName,
                            Email = customerEmail,
                            Phone = customerPhone
                        };

                        string jsonLeadData = JsonConvert.SerializeObject(leadData);

                        using (HttpClient client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
                            client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                            var response = await client.PostAsync(createLeadEndpoint, new StringContent(jsonLeadData, Encoding.UTF8, "application/json"));

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Customer details integrated with CRM successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to integrate customer details with CRM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Customer Details";
            saveFileDialog.FileName = "customer_details.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is Panel && control.Name == "dynamicPanel")
                            {
                                foreach (Control innerControl in control.Controls)
                                {
                                    if (innerControl is TextBox)
                                    {
                                        writer.WriteLine(((TextBox)innerControl).Text);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while saving details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected customer details?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                deletedPanels = this.Controls.Find("dynamicPanel", true) as Panel[];

                foreach (Control control in this.Controls)
                {
                    if (control is Panel && control.Name == "dynamicPanel")
                    {
                        this.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                MessageBox.Show("Selected customer details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Search by name...")
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                foreach (Control control in this.Controls)
                {
                    if (control is Panel && control.Name == "dynamicPanel" && control.Visible)
                    {
                        TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                        if (textBox != null)
                        {
                            string customerDetail = textBox.Text.ToLower();
                            if (customerDetail.Contains(searchText))
                            {
                                EditCustomerForm editForm = new EditCustomerForm();
                                editForm.CustomerDetails = textBox.Text;
                                editForm.ShowDialog();

                                if (editForm.DialogResult == DialogResult.OK)
                                {
                                    UpdateCustomerDetails(editForm.CustomerDetails);
                                }
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("No matching customer found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a search query first.", "No Search Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateCustomerDetails(string customerDetails)
        {
            throw new NotImplementedException();
        }

        private void SortCustomerDetailsByCriterion(string selectedOption)
        {
            throw new NotImplementedException();
        }

        private void DisplayCustomerDetails(string sampleDetails)
        {
            throw new NotImplementedException();
        }

        private void btnExportToPDF_Click(object sender, EventArgs e) { 

            
        }

        private void MultipleCustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }


    }
}
