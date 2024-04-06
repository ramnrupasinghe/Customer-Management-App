using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    

    public partial class EditTransactionForm : Form
    {
        private Transaction toEdit;

        public TTransaction editedTransaction { get; private set; }

        public EditTransactionForm(TTransaction transaction)
        {
            InitializeComponent();
            editedTransaction = transaction;

            txtTransactionAmount.Text = editedTransaction.Transactionn.ToString();
            txtTransactionDescription.Text = editedTransaction.Descriptionn;
            dateTimePickerTransactionDate.Value = editedTransaction.TransactionDate;

            cboTransactionType.Items.AddRange(Enum.GetNames(typeof(TransactionType)));
            cboTransactionType.SelectedItem = editedTransaction.Type.ToString();

            txtTransactionTags.Text = string.Join(", ", editedTransaction.Tags);
        }

        public EditTransactionForm(Transaction toEdit)
        {
            this.toEdit = toEdit;
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

            if (Enum.TryParse<TransactionType>(cboTransactionType.SelectedItem.ToString(), out TransactionType type))
            {
                editedTransaction.Type = type;
            }

            editedTransaction.Tags.Clear();
            string[] tags = txtTransactionTags.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tag in tags)
            {
                editedTransaction.Tags.Add(tag.Trim());
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboTransactionCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
