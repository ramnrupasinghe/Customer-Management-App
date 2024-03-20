using System;
using System.IO;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf;

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

            SaveCustomerDetailsToPDF(customer);
        }

        private void SaveCustomerDetailsToPDF(Customer customer)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Export Customer Details";
            saveFileDialog.FileName = "customer_details.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;

                using (FileStream fs = new FileStream(exportFilePath, FileMode.Create))
                {
                    PdfWriter writer = new PdfWriter(fs);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Add metadata
                    pdf.GetDocumentInfo().SetTitle("Customer Details");
                    pdf.GetDocumentInfo().SetSubject("Exported Customer Details");
                    pdf.GetDocumentInfo().SetCreator("Customer Management App");

                    // Add header
                    Paragraph header = new Paragraph("Customer Details\n\n");
                    header.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    document.Add(header);

                    // Add content
                    Table table = new Table(2, false);
                    table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                    AddCell(table, "Name");
                    AddCell(table, customer.Name);
                    AddCell(table, "Email");
                    AddCell(table, customer.Email);
                    AddCell(table, "Phone");
                    AddCell(table, customer.Phone);
                    AddCell(table, "Address");
                    AddCell(table, customer.Address);
                    AddCell(table, "Company Name");
                    AddCell(table, customer.CompanyName);
                    AddCell(table, "Notes");
                    AddCell(table, customer.Notes);

                    document.Add(table);
                    document.Close();
                }

                MessageBox.Show($"Customer details exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddCell(Table table, string text)
        {
            Cell cell = new Cell().Add(new Paragraph(text));
            table.AddCell(cell);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayCustomerDetails(customer);
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

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }
        private void txtCompanyName_TextChanged(object sender, EventArgs e) { }
        private void txtNotes_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

    }
}
