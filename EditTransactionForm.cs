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

            txtTransactionAmount.Text = editedTransaction.TransactionAmount.ToString();
            txtTransactionDescription.Text = editedTransaction.Description;
            dateTimePickerTransactionDate.Value = editedTransaction.Date;
            cboTransactionCategory.SelectedItem = editedTransaction.TransactionCategory;
            cboTransactionCurrency.SelectedItem = editedTransaction.TransactionCurrency;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            editedTransaction.TransactionAmount = decimal.Parse(txtTransactionAmount.Text);
            editedTransaction.Description = txtTransactionDescription.Text;
            editedTransaction.Date = dateTimePickerTransactionDate.Value;
            editedTransaction.TransactionCategory = cboTransactionCategory.SelectedItem.ToString();
            editedTransaction.TransactionCurrency = cboTransactionCurrency.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
