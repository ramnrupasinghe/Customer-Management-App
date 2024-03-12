using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class TransactionForm : Form
    {
        private decimal previousAmount;
        private string previousDescription;
        private DateTime previousDate;
        private string previousCategory;
        private string previousCurrency;

        public TransactionForm()
        {
            InitializeComponent();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Transaction myTransaction = new Transaction(
                    dateTimePickerTransactionDate.Value,
                    decimal.Parse(txtTransactionAmount.Text),
                    txtTransactionDescription.Text,
                    cboTransactionCategory.SelectedItem.ToString(),
                    cboTransactionCurrency.SelectedItem.ToString()
                );

               
                previousAmount = decimal.Parse(txtTransactionAmount.Text);
                previousDescription = txtTransactionDescription.Text;
                previousDate = dateTimePickerTransactionDate.Value;
                previousCategory = cboTransactionCategory.SelectedItem.ToString();
                previousCurrency = cboTransactionCurrency.SelectedItem.ToString();

                
                TransactionAmount = previousAmount;
                TransactionDescription = previousDescription;
                TransactionDate = previousDate;
                TransactionCategory = previousCategory;
                TransactionCurrency = previousCurrency;

                
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter valid data for all fields.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            if (previousAmount != 0 || previousDescription != null || previousDate != DateTime.MinValue ||
                previousCategory != null || previousCurrency != null)
            {
                
                Transaction transactionToEdit = new Transaction(previousDate, previousAmount, previousDescription, previousCategory, previousCurrency);

               
                using (EditTransactionForm editForm = new EditTransactionForm(transactionToEdit))
                {
                  
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        previousAmount = editForm.editedTransaction.TransactionAmount;
                        previousDescription = editForm.editedTransaction.Description;
                        previousDate = editForm.editedTransaction.Date;
                        

                        MessageBox.Show("Transaction edited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No transaction to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTransactionAmount.Text) ||
                string.IsNullOrWhiteSpace(txtTransactionDescription.Text) ||
                cboTransactionCategory.SelectedItem == null ||
                cboTransactionCurrency.SelectedItem == null)
            {
                return false;
            }

            decimal amount;
            if (!decimal.TryParse(txtTransactionAmount.Text, out amount))
            {
                return false;
            }

            return true;
        }

        

       
        public decimal TransactionAmount { get; private set; }
        public string TransactionDescription { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string TransactionCategory { get; private set; }
        public string TransactionCurrency { get; private set; }
    }
}
