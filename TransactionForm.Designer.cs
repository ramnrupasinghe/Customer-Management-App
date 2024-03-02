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
            this.SuspendLayout();
            
            this.lblTransactionAmount.AutoSize = true;
            this.lblTransactionAmount.Location = new System.Drawing.Point(16, 18);
            this.lblTransactionAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionAmount.Name = "lblTransactionAmount";
            this.lblTransactionAmount.Size = new System.Drawing.Size(129, 16);
            this.lblTransactionAmount.TabIndex = 0;
            this.lblTransactionAmount.Text = "Transaction Amount:";
             
            this.txtTransactionAmount.Location = new System.Drawing.Point(183, 15);
            this.txtTransactionAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            
            this.txtTransactionDescription.Location = new System.Drawing.Point(209, 47);
            this.txtTransactionDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTransactionDescription.Name = "txtTransactionDescription";
            this.txtTransactionDescription.Size = new System.Drawing.Size(239, 22);
            this.txtTransactionDescription.TabIndex = 3;
            
            this.btnAddTransaction.Location = new System.Drawing.Point(349, 111);
            this.btnAddTransaction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(100, 28);
            this.btnAddTransaction.TabIndex = 4;
            this.btnAddTransaction.Text = "Add";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            
            this.dateTimePickerTransactionDate.Location = new System.Drawing.Point(183, 79);
            this.dateTimePickerTransactionDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            
            this.button1.Location = new System.Drawing.Point(197, 113);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 154);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTransactionDate);
            this.Controls.Add(this.dateTimePickerTransactionDate);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.txtTransactionDescription);
            this.Controls.Add(this.lblTransactionDescription);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.lblTransactionAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Transaction";
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
    }
}
