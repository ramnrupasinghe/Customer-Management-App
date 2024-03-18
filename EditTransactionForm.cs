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

            
            txtTransactionAmount.Text = editedTransaction.Transactionn.ToString();
            txtTransactionDescription.Text = editedTransaction.Descriptionn;
            dateTimePickerTransactionDate.Value = editedTransaction.TransactionDate;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!decimal.TryParse(txtTransactionAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid transaction amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            editedTransaction.Transactionn = amount;
            editedTransaction.Descriptionn = txtTransactionDescription.Text;
            editedTransaction.TransactionDate = dateTimePickerTransactionDate.Value;
           


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
