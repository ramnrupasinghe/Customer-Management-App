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
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!decimal.TryParse(txtTransactionAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid transaction amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            editedTransaction.TransactionAmount = amount;
            editedTransaction.Description = txtTransactionDescription.Text;
            editedTransaction.Date = dateTimePickerTransactionDate.Value;
           


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
