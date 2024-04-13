using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class EmailReminderForm : Form
    {
        public EmailReminderForm()
        {
            InitializeComponent();
        }

        private void EmailReminderForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSendEmailReminder_Click(object sender, EventArgs e)
        {
            string emailAddress = Microsoft.VisualBasic.Interaction.InputBox("Enter your email address:", "Send Email Reminder", "");

            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                  
                    mail.From = new MailAddress("manurirupasinghe100@gmail.com");
                  
                    mail.To.Add(emailAddress);
                  
                    mail.Subject = "Reminder: Important Task";
                  
                    mail.Body = "Don't forget to complete the important task!";
                  
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                   
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                 
                    smtp.Credentials = new NetworkCredential("your-smtp-username", "your-smtp-password"); 
                    
                    smtp.Send(mail);

                    MessageBox.Show($"Email reminder sent to: {emailAddress}", "Email Reminder Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while sending the email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No email address entered.", "Email Reminder Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
