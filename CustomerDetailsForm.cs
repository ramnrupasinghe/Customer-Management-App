using System;
using System.IO;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class CustomerDetailsForm : Form
    {
        private Customer customer;
        private string[] previousData;

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

            
            SaveCustomerDetailsToCSV(customer);
        }

        private void SaveCustomerDetailsToCSV(Customer customer)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Customer Details";
            saveFileDialog.FileName = "customer_details.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;

                using (var writer = new StreamWriter(exportFilePath))
                {
                    writer.WriteLine("Name,Email,Phone,Address,CompanyName,Notes");
                    string name = customer.Name ?? "";
                    string email = customer.Email ?? "";
                    string phone = customer.Phone ?? "";
                    string address = customer.Address ?? "";
                    string companyName = customer.CompanyName ?? "";
                    string notes = customer.Notes ?? "";

                    writer.WriteLine($"{name},{email},{phone},{address},{companyName},{notes}");
                }

                MessageBox.Show($"Customer details exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void ClearTextBoxes()
        {

            previousData = new string[]
            {
                txtName.Text,
                txtEmail.Text,
                txtPhone.Text,
                txtAddress.Text,
                txtCompanyName.Text,
                txtNotes.Text
            };


            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCompanyName.Clear();
            txtNotes.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int totalNoteLength = txtNotes.Text.Length;
            MessageBox.Show($"Total length of notes: {totalNoteLength}");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (previousData != null && previousData.Length == 6)
            {
                txtName.Text = previousData[0];
                txtEmail.Text = previousData[1];
                txtPhone.Text = previousData[2];
                txtAddress.Text = previousData[3];
                txtCompanyName.Text = previousData[4];
                txtNotes.Text = previousData[5];
            }
        }
    }
}
