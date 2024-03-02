using System;
using System.IO;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class TransactionForm : Form
    {
        public decimal TransactionAmount { get; private set; }
        public string TransactionDescription { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public TransactionForm()
        {
            InitializeComponent();
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            TransactionAmount = decimal.Parse(txtTransactionAmount.Text);
            TransactionDescription = txtTransactionDescription.Text;
            TransactionDate = dateTimePickerTransactionDate.Value;

            DialogResult = DialogResult.OK;
            Close();
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

                using (var writer = new StreamWriter(exportFilePath, true))
                {
                    writer.WriteLine("Transaction Date,Amount,Description");
                    string transactionDate = TransactionDate.ToString();
                    string amount = TransactionAmount.ToString();
                    string description = TransactionDescription;

                    writer.WriteLine($"{transactionDate},{amount},{description}");
                }

                MessageBox.Show($"Transaction data exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
