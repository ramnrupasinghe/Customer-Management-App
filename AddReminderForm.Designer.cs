﻿namespace CustomerManagementApp
{
    partial class AddReminderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker datePickerDueDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCharacterCounter;
        private System.Windows.Forms.DateTimePicker timePickerReminderTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.datePickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCharacterCounter = new System.Windows.Forms.Label();
            this.timePickerReminderTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(35, 45);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(298, 134);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // datePickerDueDate
            // 
            this.datePickerDueDate.Location = new System.Drawing.Point(35, 185);
            this.datePickerDueDate.Name = "datePickerDueDate";
            this.datePickerDueDate.Size = new System.Drawing.Size(298, 22);
            this.datePickerDueDate.TabIndex = 3;
            this.datePickerDueDate.ValueChanged += new System.EventHandler(this.datePickerDueDate_ValueChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(32, 15);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(130, 16);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Adding reminder for: ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cbPriority
            // 
            this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(38, 240);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(121, 24);
            this.cbPriority.TabIndex = 5;
            this.cbPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(212, 240);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 24);
            this.cbCategory.TabIndex = 6;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Category";
            // 
            // lblCharacterCounter
            // 
            this.lblCharacterCounter.AutoSize = true;
            this.lblCharacterCounter.Location = new System.Drawing.Point(35, 350);
            this.lblCharacterCounter.Name = "lblCharacterCounter";
            this.lblCharacterCounter.Size = new System.Drawing.Size(0, 16);
            this.lblCharacterCounter.TabIndex = 9;
            // 
            // timePickerReminderTime
            // 
            this.timePickerReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerReminderTime.Location = new System.Drawing.Point(99, 286);
            this.timePickerReminderTime.Name = "timePickerReminderTime";
            this.timePickerReminderTime.ShowUpDown = true;
            this.timePickerReminderTime.Size = new System.Drawing.Size(200, 22);
            this.timePickerReminderTime.TabIndex = 10;
            this.timePickerReminderTime.ValueChanged += new System.EventHandler(this.timePickerReminderTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Remind me at :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Notify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Attach ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 400);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePickerReminderTime);
            this.Controls.Add(this.lblCharacterCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbPriority);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.datePickerDueDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddReminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Reminder";
            this.Load += new System.EventHandler(this.AddReminderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
