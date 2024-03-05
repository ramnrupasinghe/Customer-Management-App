namespace CustomerManagementApp
{
    partial class EditTransactionForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.lblTransactionAmount = new System.Windows.Forms.Label();
            this.lblTransactionDescription = new System.Windows.Forms.Label();
            this.lblTransactionCategory = new System.Windows.Forms.Label();
            this.lblTransactionCurrency = new System.Windows.Forms.Label();
            this.dateTimePickerTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.txtTransactionDescription = new System.Windows.Forms.TextBox();
            this.cboTransactionCategory = new System.Windows.Forms.ComboBox();
            this.cboTransactionCurrency = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
           
            this.btnSave.Location = new System.Drawing.Point(137, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
           
            this.btnCancel.Location = new System.Drawing.Point(237, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Location = new System.Drawing.Point(27, 29);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(89, 13);
            this.lblTransactionDate.TabIndex = 2;
            this.lblTransactionDate.Text = "Transaction Date:";
            
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(27, 59);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(106, 13);
            this.lblTransactionAmount.TabIndex = 3;
            this.lblTransactionAmount.Text = "Transaction Amount:";
           
            this.lblTransactionDescription.AutoSize = true;
            this.lblTransactionDescription.Location = new System.Drawing.Point(27, 89);
            this.lblTransactionDescription.Name = "lblTransactionDescription";
            this.lblTransactionDescription.Size = new System.Drawing.Size(119, 13);
            this.lblTransactionDescription.TabIndex = 4;
            this.lblTransactionDescription.Text = "Transaction Description:";
           
            this.lblTransactionCategory.AutoSize = true;
            this.lblTransactionCategory.Location = new System.Drawing.Point(27, 119);
            this.lblTransactionCategory.Name = "lblTransactionCategory";
            this.lblTransactionCategory.Size = new System.Drawing.Size(106, 13);
            this.lblTransactionCategory.TabIndex = 5;
            this.lblTransactionCategory.Text = "Transaction Category:";
            
            this.lblTransactionCurrency.AutoSize = true;
            this.lblTransactionCurrency.Location = new System.Drawing.Point(27, 149);
            this.lblTransactionCurrency.Name = "lblTransactionCurrency";
            this.lblTransactionCurrency.Size = new System.Drawing.Size(107, 13);
            this.lblTransactionCurrency.TabIndex = 6;
            this.lblTransactionCurrency.Text = "Transaction Currency:";
            
            this.dateTimePickerTransactionDate.Location = new System.Drawing.Point(159, 29);
            this.dateTimePickerTransactionDate.Name = "dateTimePickerTransactionDate";
            this.dateTimePickerTransactionDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTransactionDate.TabIndex = 7;
          
            this.txtTransactionAmount.Location = new System.Drawing.Point(159, 59);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(200, 20);
            this.txtTransactionAmount.TabIndex = 8;
           
            this.txtTransactionDescription.Location = new System.Drawing.Point(159, 89);
            this.txtTransactionDescription.Name = "txtTransactionDescription";
            this.txtTransactionDescription.Size = new System.Drawing.Size(200, 20);
            this.txtTransactionDescription.TabIndex = 9;
           
            this.cboTransactionCategory.FormattingEnabled = true;
            this.cboTransactionCategory.Location = new System.Drawing.Point(159, 119);
            this.cboTransactionCategory.Name = "cboTransactionCategory";
            this.cboTransactionCategory.Size = new System.Drawing.Size(200, 21);
            this.cboTransactionCategory.TabIndex = 10;
           
            this.cboTransactionCurrency.FormattingEnabled = true;
            this.cboTransactionCurrency.Location = new System.Drawing.Point(159, 149);
            this.cboTransactionCurrency.Name = "cboTransactionCurrency";
            this.cboTransactionCurrency.Size = new System.Drawing.Size(200, 21);
            this.cboTransactionCurrency.TabIndex = 11;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 256);
            this.Controls.Add(this.cboTransactionCurrency);
            this.Controls.Add(this.cboTransactionCategory);
            this.Controls.Add(this.txtTransactionDescription);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.dateTimePickerTransactionDate);
            this.Controls.Add(this.lblTransactionCurrency);
            this.Controls.Add(this.lblTransactionCategory);
            this.Controls.Add(this.lblTransactionDescription);
            this.Controls.Add(this.lblTransactionAmount);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "EditTransactionForm";
            this.Text = "Edit Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label lblTransactionAmount;
        private System.Windows.Forms.Label lblTransactionDescription;
        private System.Windows.Forms.Label lblTransactionCategory;
        private System.Windows.Forms.Label lblTransactionCurrency;
        private System.Windows.Forms.DateTimePicker dateTimePickerTransactionDate;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.TextBox txtTransactionDescription;
        private System.Windows.Forms.ComboBox cboTransactionCategory;
        private System.Windows.Forms.ComboBox cboTransactionCurrency;
    }
}
