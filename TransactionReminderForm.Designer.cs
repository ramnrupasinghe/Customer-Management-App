namespace CustomerManagementApp
{
    partial class TransactionReminderForm
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.listBoxAttachedFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(105, 21);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(315, 22);
            this.datePicker.TabIndex = 0;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(24, 21);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(64, 16);
            this.lblDueDate.TabIndex = 1;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 57);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(315, 60);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.cmbPriority.Location = new System.Drawing.Point(105, 133);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(315, 24);
            this.cmbPriority.TabIndex = 4;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(24, 133);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 16);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "Priority";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(24, 173);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Meeting",
            "Follow-up",
            "Deadline",
            "Other"});
            this.cmbCategory.Location = new System.Drawing.Point(105, 173);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(315, 24);
            this.cmbCategory.TabIndex = 7;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOK.Location = new System.Drawing.Point(24, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 61);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(344, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 61);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Location = new System.Drawing.Point(123, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "Snooze";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAttachFile.Location = new System.Drawing.Point(232, 277);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(84, 61);
            this.btnAttachFile.TabIndex = 11;
            this.btnAttachFile.Text = "Attach File";
            this.btnAttachFile.UseVisualStyleBackColor = false;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // listBoxAttachedFiles
            // 
            this.listBoxAttachedFiles.FormattingEnabled = true;
            this.listBoxAttachedFiles.ItemHeight = 16;
            this.listBoxAttachedFiles.Location = new System.Drawing.Point(105, 203);
            this.listBoxAttachedFiles.Name = "listBoxAttachedFiles";
            this.listBoxAttachedFiles.Size = new System.Drawing.Size(315, 36);
            this.listBoxAttachedFiles.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Attachment";
            // 
            // TransactionReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 373);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAttachedFiles);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.datePicker);
            this.Name = "TransactionReminderForm";
            this.Text = "Transaction Reminder";
            this.Load += new System.EventHandler(this.TransactionReminderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.ListBox listBoxAttachedFiles;
        private System.Windows.Forms.Label label1;
    }
}