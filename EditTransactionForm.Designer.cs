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
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 272);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(316, 272);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Location = new System.Drawing.Point(36, 36);
            this.lblTransactionDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(113, 16);
            this.lblTransactionDate.TabIndex = 2;
            this.lblTransactionDate.Text = "Transaction Date:";
            // 
            // lblTransactionAmount
            // 
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(36, 73);
            this.lblTransactionAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(129, 16);
            this.lblTransactionAmount.TabIndex = 3;
            this.lblTransactionAmount.Text = "Transaction Amount:";
            // 
            // lblTransactionDescription
            // 
            this.lblTransactionDescription.AutoSize = true;
            this.lblTransactionDescription.Location = new System.Drawing.Point(36, 110);
            this.lblTransactionDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionDescription.Name = "lblTransactionDescription";
            this.lblTransactionDescription.Size = new System.Drawing.Size(152, 16);
            this.lblTransactionDescription.TabIndex = 4;
            this.lblTransactionDescription.Text = "Transaction Description:";
            // 
            // lblTransactionCategory
            // 
            this.lblTransactionCategory.AutoSize = true;
            this.lblTransactionCategory.Location = new System.Drawing.Point(36, 146);
            this.lblTransactionCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionCategory.Name = "lblTransactionCategory";
            this.lblTransactionCategory.Size = new System.Drawing.Size(139, 16);
            this.lblTransactionCategory.TabIndex = 5;
            this.lblTransactionCategory.Text = "Transaction Category:";
            // 
            // lblTransactionCurrency
            // 
            this.lblTransactionCurrency.AutoSize = true;
            this.lblTransactionCurrency.Location = new System.Drawing.Point(36, 183);
            this.lblTransactionCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionCurrency.Name = "lblTransactionCurrency";
            this.lblTransactionCurrency.Size = new System.Drawing.Size(137, 16);
            this.lblTransactionCurrency.TabIndex = 6;
            this.lblTransactionCurrency.Text = "Transaction Currency:";
            // 
            // dateTimePickerTransactionDate
            // 
            this.dateTimePickerTransactionDate.Location = new System.Drawing.Point(212, 36);
            this.dateTimePickerTransactionDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerTransactionDate.Name = "dateTimePickerTransactionDate";
            this.dateTimePickerTransactionDate.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerTransactionDate.TabIndex = 7;
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.Location = new System.Drawing.Point(212, 110);
            this.txtTransactionAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(265, 22);
            this.txtTransactionAmount.TabIndex = 8;
            this.txtTransactionAmount.TextChanged += new System.EventHandler(this.txtTransactionAmount_TextChanged);
            // 
            // txtTransactionDescription
            // 
            this.txtTransactionDescription.Location = new System.Drawing.Point(212, 73);
            this.txtTransactionDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTransactionDescription.Name = "txtTransactionDescription";
            this.txtTransactionDescription.Size = new System.Drawing.Size(265, 22);
            this.txtTransactionDescription.TabIndex = 9;
            this.txtTransactionDescription.TextChanged += new System.EventHandler(this.txtTransactionDescription_TextChanged);
            // 
            // cboTransactionCategory
            // 
            this.cboTransactionCategory.FormattingEnabled = true;
            this.cboTransactionCategory.Location = new System.Drawing.Point(212, 146);
            this.cboTransactionCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTransactionCategory.Name = "cboTransactionCategory";
            this.cboTransactionCategory.Size = new System.Drawing.Size(265, 24);
            this.cboTransactionCategory.TabIndex = 10;
            // 
            // cboTransactionCurrency
            // 
            this.cboTransactionCurrency.FormattingEnabled = true;
            this.cboTransactionCurrency.Location = new System.Drawing.Point(212, 183);
            this.cboTransactionCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTransactionCurrency.Name = "cboTransactionCurrency";
            this.cboTransactionCurrency.Size = new System.Drawing.Size(265, 24);
            this.cboTransactionCurrency.TabIndex = 11;
            // 
            // EditTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 315);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
