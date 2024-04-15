namespace CustomerManagementApp
{
    partial class EmailReminderForm
    {
        
        private System.ComponentModel.IContainer components = null;

        
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

       
        private void InitializeComponent()
        {
            this.btnSendEmailReminder = new System.Windows.Forms.Button();
            this.txtAttachmentFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSmtpUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
           
            this.btnSendEmailReminder.Location = new System.Drawing.Point(332, 392);
            this.btnSendEmailReminder.Name = "btnSendEmailReminder";
            this.btnSendEmailReminder.Size = new System.Drawing.Size(136, 46);
            this.btnSendEmailReminder.TabIndex = 0;
            this.btnSendEmailReminder.Text = "Send Email Reminder";
            this.btnSendEmailReminder.UseVisualStyleBackColor = true;
            this.btnSendEmailReminder.Click += new System.EventHandler(this.btnSendEmailReminder_Click);
           
            this.txtAttachmentFilePath.Location = new System.Drawing.Point(188, 97);
            this.txtAttachmentFilePath.Name = "txtAttachmentFilePath";
            this.txtAttachmentFilePath.Size = new System.Drawing.Size(387, 22);
            this.txtAttachmentFilePath.TabIndex = 1;
         
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attachment Path: ";
         
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SMTP Username:";
           
            this.txtSmtpUsername.Location = new System.Drawing.Point(188, 156);
            this.txtSmtpUsername.Name = "txtSmtpUsername";
            this.txtSmtpUsername.Size = new System.Drawing.Size(387, 22);
            this.txtSmtpUsername.TabIndex = 3;
        
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "SMTP Password:";
          
            this.txtSmtpPassword.Location = new System.Drawing.Point(188, 215);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '*';
            this.txtSmtpPassword.Size = new System.Drawing.Size(387, 22);
            this.txtSmtpPassword.TabIndex = 5;
         
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 477);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSmtpPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSmtpUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAttachmentFilePath);
            this.Controls.Add(this.btnSendEmailReminder);
            this.Name = "EmailReminderForm";
            this.Text = "Email Reminder Form";
            this.Load += new System.EventHandler(this.EmailReminderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendEmailReminder;
        private System.Windows.Forms.TextBox txtAttachmentFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSmtpUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSmtpPassword;
    }
}
