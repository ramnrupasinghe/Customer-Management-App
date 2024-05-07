using System;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LiveCharts;
using LiveCharts.WinForms;
using System.Linq;
using System.Collections.Generic;
using LiveCharts.Wpf;

namespace CustomerManagementApp
{
    public partial class TransactionForm : Form
    {

        private void PopulateListView(List<Transaction> transactions)
        {
    
            listViewTransactions.Items.Clear();

           
            foreach (var transaction in transactions)
            {
                ListViewItem item = new ListViewItem(transaction.TransactionDate.ToShortDateString());
                item.SubItems.Add(transaction.Descriptionn);
                item.SubItems.Add(transaction.Transactionn.ToString());
                item.SubItems.Add(transaction.Currency);
                item.SubItems.Add(transaction.Category);
                listViewTransactions.Items.Add(item);
            }
        }

        private decimal previousAmount;
        private string previousDescription;
        private DateTime previousDate;
        private string previousCategory;
        private string previousCurrency;
        private List<Transaction> transactionList = new List<Transaction>();
        private ListView listViewTransactions;
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
                
                Transaction ToEdit = new Transaction(previousDate, previousAmount, previousDescription, previousCategory, previousCurrency);

               
                using (EditTransactionForm editForm = new EditTransactionForm(ToEdit))
                {
                  
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        previousAmount = editForm.editedTransaction.Transactionn;
                        previousDescription = editForm.editedTransaction.Descriptionn;
                        previousDate = editForm.editedTransaction.TransactionDate;


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

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }

        private void cboTransactionCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnSortTransactions_Click(object sender, EventArgs e)
        {

            if (transactionList.Count > 0)
            {
                transactionList = transactionList.OrderBy(t => t.TransactionDate).ToList();
                PopulateListView(transactionList);
            }
            else
            {
                MessageBox.Show("No transactions to sort.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnShowGraph_Click(object sender, EventArgs e)
        {
            if (transactionList.Count > 0)
            {
                var transactionDates = transactionList.Select(t => t.TransactionDate).ToArray();
                var transactionAmounts = transactionList.Select(t => (double)t.Transactionn).ToArray();

                var chart = new LiveCharts.WinForms.CartesianChart
                {
                    Series = new LiveCharts.SeriesCollection
            {
                new LiveCharts.Wpf.LineSeries
                {
                    Title = "Transaction Amount",
                    Values = new LiveCharts.ChartValues<double>(transactionAmounts)
                }
            },
                  
                };

                var form = new Form();
                form.Controls.Add(chart);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No transactions to display.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExportToPDF_Click(object sender, EventArgs e)
        {


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (PdfWriter writer = new PdfWriter(saveFileDialog.FileName))
                        {
                            using (PdfDocument pdf = new PdfDocument(writer))
                            {
                                Document document = new Document(pdf);
                                document.Add(new Paragraph("Transaction Report"));

                                foreach (var transaction in transactionList)
                                {
                                    document.Add(new Paragraph($"{transaction.TransactionDate.ToShortDateString()} - {transaction.Descriptionn} - {transaction.Transactionn} {transaction.Currency}"));
                                }
                            }
                        }

                        MessageBox.Show("Transactions exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
