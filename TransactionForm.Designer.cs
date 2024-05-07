namespace CustomerManagementApp
{
    partial class TransactionForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblTransactionAmount = new System.Windows.Forms.Label();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.lblTransactionDescription = new System.Windows.Forms.Label();
            this.txtTransactionDescription = new System.Windows.Forms.TextBox();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.dateTimePickerTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTransactionCategory = new System.Windows.Forms.Label();
            this.cboTransactionCategory = new System.Windows.Forms.ComboBox();
            this.lblTransactionCurrency = new System.Windows.Forms.Label();
            this.cboTransactionCurrency = new System.Windows.Forms.ComboBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
         
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(16, 18);
            this.lblTransactionAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(129, 16);
            this.lblTransactionAmount.TabIndex = 0;
            this.lblTransactionAmount.Text = "Transaction Amount:";
           
            this.txtTransactionAmount.Location = new System.Drawing.Point(183, 15);
            this.txtTransactionAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(265, 22);
            this.txtTransactionAmount.TabIndex = 1;
           
            this.lblTransactionDescription.AutoSize = true;
            this.lblTransactionDescription.Location = new System.Drawing.Point(16, 50);
            this.lblTransactionDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionDescription.Name = "lblTransactionDescription";
            this.lblTransactionDescription.Size = new System.Drawing.Size(152, 16);
            this.lblTransactionDescription.TabIndex = 2;
            this.lblTransactionDescription.Text = "Transaction Description:";
           
            this.txtTransactionDescription.Location = new System.Drawing.Point(183, 45);
            this.txtTransactionDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionDescription.Name = "txtTransactionDescription";
            this.txtTransactionDescription.Size = new System.Drawing.Size(265, 22);
            this.txtTransactionDescription.TabIndex = 3;
           
            this.btnAddTransaction.Location = new System.Drawing.Point(13, 300);
            this.btnAddTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(100, 45);
            this.btnAddTransaction.TabIndex = 4;
            this.btnAddTransaction.Text = "Add";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
          
            this.dateTimePickerTransactionDate.Location = new System.Drawing.Point(183, 79);
            this.dateTimePickerTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTransactionDate.Name = "dateTimePickerTransactionDate";
            this.dateTimePickerTransactionDate.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerTransactionDate.TabIndex = 5;
           
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Location = new System.Drawing.Point(16, 86);
            this.lblTransactionDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(113, 16);
            this.lblTransactionDate.TabIndex = 6;
            this.lblTransactionDate.Text = "Transaction Date:";
           
            this.button1.Location = new System.Drawing.Point(13, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            this.lblTransactionCategory.AutoSize = true;
            this.lblTransactionCategory.Location = new System.Drawing.Point(16, 119);
            this.lblTransactionCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionCategory.Name = "lblTransactionCategory";
            this.lblTransactionCategory.Size = new System.Drawing.Size(139, 16);
            this.lblTransactionCategory.TabIndex = 8;
            this.lblTransactionCategory.Text = "Transaction Category:";
           
            this.cboTransactionCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionCategory.FormattingEnabled = true;
            this.cboTransactionCategory.Items.AddRange(new object[] {
            "Groceries",
            "Dining Out",
            "Transportation",
            "Entertainment",
            "Debt Repayment"});
            this.cboTransactionCategory.Location = new System.Drawing.Point(183, 116);
            this.cboTransactionCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransactionCategory.Name = "cboTransactionCategory";
            this.cboTransactionCategory.Size = new System.Drawing.Size(160, 24);
            this.cboTransactionCategory.TabIndex = 9;
            
            this.lblTransactionCurrency.AutoSize = true;
            this.lblTransactionCurrency.Location = new System.Drawing.Point(16, 151);
            this.lblTransactionCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionCurrency.Name = "lblTransactionCurrency";
            this.lblTransactionCurrency.Size = new System.Drawing.Size(137, 16);
            this.lblTransactionCurrency.TabIndex = 10;
            this.lblTransactionCurrency.Text = "Transaction Currency:";
            
            this.cboTransactionCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionCurrency.FormattingEnabled = true;
            this.cboTransactionCurrency.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "GBP",
            "JPY",
            "CAD",
            "AUD",
            "CHF",
            "CNY"});
            this.cboTransactionCurrency.Location = new System.Drawing.Point(183, 148);
            this.cboTransactionCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransactionCurrency.Name = "cboTransactionCurrency";
            this.cboTransactionCurrency.Size = new System.Drawing.Size(160, 24);
            this.cboTransactionCurrency.TabIndex = 11;
            this.cboTransactionCurrency.SelectedIndexChanged += new System.EventHandler(this.cboTransactionCurrency_SelectedIndexChanged);
           
            this.btnAddCategory.Location = new System.Drawing.Point(350, 115);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(30, 25);
            this.btnAddCategory.TabIndex = 12;
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            
            this.button2.Location = new System.Drawing.Point(183, 216);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 45);
            this.button2.TabIndex = 13;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
           
            this.button3.Location = new System.Drawing.Point(183, 300);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 45);
            this.button3.TabIndex = 14;
            this.button3.Text = "Undo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
             
            this.button4.Location = new System.Drawing.Point(335, 216);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 45);
            this.button4.TabIndex = 15;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
           
            this.button5.Location = new System.Drawing.Point(316, 300);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 45);
            this.button5.TabIndex = 16;
            this.button5.Text = "Calculate Total Transaction";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 365);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.cboTransactionCurrency);
            this.Controls.Add(this.lblTransactionCurrency);
            this.Controls.Add(this.cboTransactionCategory);
            this.Controls.Add(this.lblTransactionCategory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.dateTimePickerTransactionDate);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.txtTransactionDescription);
            this.Controls.Add(this.lblTransactionDescription);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.lblTransactionAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Transaction";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTransactionAmount;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.Label lblTransactionDescription;
        private System.Windows.Forms.TextBox txtTransactionDescription;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.DateTimePicker dateTimePickerTransactionDate;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTransactionCategory;
        private System.Windows.Forms.ComboBox cboTransactionCategory;
        private System.Windows.Forms.Label lblTransactionCurrency;
        private System.Windows.Forms.ComboBox cboTransactionCurrency;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
