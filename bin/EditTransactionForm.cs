using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class EditTransactionForm : Form
    {
        public Transaction editedTransaction { get; private set; }

        public EditTransactionForm(Transaction transaction)
        {
            InitializeComponent();
            editedTransaction = transaction;

            // Set initial values for controls
            txtTransactionAmount.Text = editedTransaction.TransactionAmount.ToString();
            txtTransactionDescription.Text = editedTransaction.Description;
            dateTimePickerTransactionDate.Value = editedTransaction.Date;
            cboTransactionCategory.SelectedItem = editedTransaction.TransactionCategory;
            cboTransactionCurrency.SelectedItem = editedTransaction.TransactionCurrency;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate and parse transaction amount
            if (!decimal.TryParse(txtTransactionAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid transaction amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update transaction properties
            editedTransaction.TransactionAmount = amount;
            editedTransaction.Description = txtTransactionDescription.Text;
            editedTransaction.Date = dateTimePickerTransactionDate.Value;
            editedTransaction.TransactionCategory = cboTransactionCategory.SelectedItem.ToString();
            editedTransaction.TransactionCurrency = cboTransactionCurrency.SelectedItem.ToString();

            // Close the form
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving changes
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
