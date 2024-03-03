using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
                txtTransactionDescription.Text = previousDescription;
                dateTimePickerTransactionDate.Value = previousDate;
                cboTransactionCategory.SelectedItem = previousCategory;
                cboTransactionCurrency.SelectedItem = previousCurrency;
            }
            else
            {
                
                txtTransactionAmount.Text = "";
                txtTransactionDescription.Text = "";
                cboTransactionCategory.SelectedIndex = -1;
                cboTransactionCurrency.SelectedIndex = -1;
                dateTimePickerTransactionDate.Value = DateTime.Now;
            }
        }

    }
}
