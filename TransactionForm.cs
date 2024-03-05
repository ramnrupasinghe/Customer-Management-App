using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CustomerManagementApp;

namespace CustomerManagementApp
{
    public partial class TransactionForm : Form
    {
        private decimal previousAmount;
        private string previousDescription;
        private DateTime previousDate;
        private string previousCategory;
        private string previousCurrency;

        public decimal TransactionAmount { get; private set; }
        public string TransactionDescription { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string TransactionCategory { get; private set; }
        public string TransactionCurrency { get; private set; }

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
                    "CurrencyValue"
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



        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = Prompt.ShowDialog("Enter new category:", "Add New Category");
            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                cboTransactionCategory.Items.Add(newCategory);
                cboTransactionCategory.SelectedItem = newCategory;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Transaction Data";
            saveFileDialog.FileName = "transactions.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;

                try
                {
                    using (var writer = new StreamWriter(exportFilePath, true))
                    {
                        writer.WriteLine("Transaction Date,Amount,Currency,Description,Category");
                        string transactionDate = TransactionDate.ToString();
                        string amount = TransactionAmount.ToString();
                        string currency = TransactionCurrency;
                        string description = TransactionDescription;
                        string category = TransactionCategory;

                        writer.WriteLine($"{transactionDate},{amount},{currency},{description},{category}");
                    }

                    MessageBox.Show($"Transaction data exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting transaction data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtTransactionAmount.Text = "";
            txtTransactionDescription.Text = "";
            cboTransactionCategory.SelectedIndex = -1;
            cboTransactionCurrency.SelectedIndex = -1;
            dateTimePickerTransactionDate.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (previousAmount != 0 || previousDescription != null || previousDate != DateTime.MinValue ||
                previousCategory != null || previousCurrency != null)
            {
                txtTransactionAmount.Text = previousAmount.ToString();
                txtTransactionDescription.Text = previousDescription ?? "";
                dateTimePickerTransactionDate.Value = previousDate != DateTime.MinValue ? previousDate : DateTime.Now;
                cboTransactionCategory.SelectedItem = previousCategory;
                cboTransactionCurrency.SelectedItem = previousCurrency;
            }
            else
            {
                MessageBox.Show("No transaction to restore.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        previousCategory = editForm.editedTransaction.TransactionCategory;
                        previousCurrency = editForm.editedTransaction.TransactionCurrency;

                        MessageBox.Show("Transaction edited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No transaction to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string selectedCategory = cboTransactionCategory.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                CalculateTotalAmountForCategory(selectedCategory);
            }
            else
            {
                MessageBox.Show("Please select a category to calculate the total amount.", "Category Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalculateTotalAmountForCategory(string category)
        {
            decimal totalAmount = 0;

         
            List<Transaction> transactions = GetAllTransactions();

            foreach (var transaction in transactions)
            {
                if (transaction.TransactionCategory == category)
                {
                    totalAmount += transaction.TransactionAmount;
                }
            }

            MessageBox.Show($"Total amount for {category}: {totalAmount}", "Total Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private List<Transaction> GetAllTransactions()
        {
            
            return new List<Transaction>();
        }
    }

   
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
        
            return "";
        }
    }
}
