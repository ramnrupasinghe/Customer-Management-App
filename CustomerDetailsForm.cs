using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using System.Net.Mail;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace CustomerManagementApp
{
    public partial class CustomerDetailsForm : Form
    {
        public Customer Customer { get; set; }
        private string[] previousData;
        private List<ActivityLog> activityLogs = new List<ActivityLog>();

        public CustomerDetailsForm(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
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
            Customer.Name = txtName.Text;
            Customer.Email = txtEmail.Text;
            Customer.Phone = txtPhone.Text;
            Customer.Address = txtAddress.Text;
            Customer.CompanyName = txtCompanyName.Text;
            Customer.Notes = txtNotes.Text;
            MessageBox.Show("Changes saved successfully!");

            SaveCustomerDetailsToPDF(Customer);
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

                    pdf.GetDocumentInfo().SetTitle("Customer Details");
                    pdf.GetDocumentInfo().SetSubject("Exported Customer Details");
                    pdf.GetDocumentInfo().SetCreator("Customer Management App");

                    Paragraph header = new Paragraph("Customer Details\n\n");
                    header.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                    document.Add(header);

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayCustomerDetails(Customer);
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

        private void button4_Click(object sender, EventArgs e)
        {
            List<ActivityLog> dummyActivityLogs = new List<ActivityLog>
            {
                new ActivityLog { CustomerName = "John Doe", ActivityType = "Call", ActivityDateTime = DateTime.Now.AddDays(-2), Details = "Called customer regarding product inquiry" },
                new ActivityLog { CustomerName = "Jane Smith", ActivityType = "Email", ActivityDateTime = DateTime.Now.AddDays(-1), Details = "Sent follow-up email to customer" },
                new ActivityLog { CustomerName = "John Doe", ActivityType = "Meeting", ActivityDateTime = DateTime.Now.AddDays(-3), Details = "Scheduled meeting with customer for next week" }
            };
            ActivityCenterForm activityCenterForm = new ActivityCenterForm(dummyActivityLogs);
            activityCenterForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587;
                smtpServer.EnableSsl = true;
                smtpServer.Credentials = new NetworkCredential("manurirupasinghe100@gmail.com", "your password");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("manurirupasinghe100@gmail.com");
                mail.To.Add(Customer.Email);
                mail.Subject = "A reminder about the latest Transaction";
                mail.Body = "Dear " + Customer.Name + ",\n\n" + "This is a test email sent from your Customer Management App.\n" +
                    "I hope this email finds you well. We wanted to take a moment to remind you about the latest transaction associated with your account. \n" +
                    "Below are the details:\n" +
                    "Transaction ID: ABC123456\r\nDate of Transaction: March 25, 2024\r\nAmount: $100.00\r\nDescription: Purchase of Product X\n" +
                    "If you have any questions or concerns regarding this transaction or if you need any assistance,\n" +
                    " please don't hesitate to contact us. We're here to help!\r\n\r\nThank you for choosing our services. We appreciate your business and look forward to continuing to serve you.\r\n\r\n" +
                    "Best regards,\n\n" +
                    "Nimaya Rupasinghe\n" +
                    "manurirupasinghe100@gmail.com";

                smtpServer.Send(mail);

                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
            LogCustomerInteraction(); //calling
        }

        private void button7_Click(object sender, EventArgs e)
        {
         
            BackupCustomerData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
          
            RestoreCustomerData();
        }

        private void LogCustomerInteraction()
        {
     
            string interactionDetails = txtInteractionDetails.Text;

          
            ActivityLog newActivity = new ActivityLog
            {
                CustomerName = Customer.Name,             
                ActivityDateTime = DateTime.Now,
                Details = interactionDetails
            };

            activityLogs.Add(newActivity);

           
            MessageBox.Show("Interaction logged successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void BackupCustomerData()
        {
            try
            {
          
                using (var connection = new SqlConnection("your_connection_string_here"))
                {
                    connection.Open();

            
                    string selectQuery = "SELECT * FROM Customers";

                
                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                     
                        using (var reader = command.ExecuteReader())
                        {
                            SaveDataToBackupFile(reader);
                        }
                    }
                }

               
                Console.WriteLine("Customer data backup completed successfully.");
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Error occurred while backing up customer data: " + ex.Message);
            }
        }

     
        private void SaveDataToBackupFile(SqlDataReader reader)
        {
          
            string backupFilePath = "backup_file_path_here";

     
            using (var writer = new StreamWriter(backupFilePath))
            {
    
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        writer.Write(reader[i].ToString() + ",");
                    }
                    writer.WriteLine();
                }
            }
        }


        private void RestoreCustomerData()
        {
       
            using (var connection = new SqlConnection("your_connection_string"))
            {
            
                connection.Open();

          
                string sqlCommandText = "RESTORE DATABASE YourDatabaseName FROM disk = 'C:\\YourBackupPath\\YourBackupFile.bak'";
                SqlCommand command = new SqlCommand(sqlCommandText, connection);

            
                command.ExecuteNonQuery();

                connection.Close();
            }
        }


        private void AddCell(Table table, string text)
        {
            Cell cell = new Cell().Add(new Paragraph(text));
            table.AddCell(cell);
        }

        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtAddress_TextChanged(object sender, EventArgs e) { }
        private void txtCompanyName_TextChanged(object sender, EventArgs e) { }
        private void txtNotes_TextChanged(object sender, EventArgs e) { }

        public class ActivityLog
        {
            public string CustomerName { get; set; }
            public string ActivityType { get; set; }
            public DateTime ActivityDateTime { get; set; }
            public string Details { get; set; }
        }

        private void txtInteractionDetails_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
