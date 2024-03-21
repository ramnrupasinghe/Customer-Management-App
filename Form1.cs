using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class Form1 : Form
    {
        private List<Customer> customers = new List<Customer>();
        private List<Reminder> reminders = new List<Reminder>();
        private Analytics analytics = new Analytics();

        public Form1()
        {
            InitializeComponent();
            dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomers.MultiSelect = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInitialCustomerData();
            RefreshDataGridView();
            analytics.AnalyzeSalesData(customers);
        }

        private void LoadInitialCustomerData()
        {
            customers.Add(new Customer { Name = "John Doe", Email = "john@example.com", Phone = "1234567890", Address = "123 Main St", CompanyName = "ABC Inc.", Notes = "Regular customer", Tags = new List<string> { "Regular" } });
            customers.Add(new Customer { Name = "Jane Smith", Email = "jane@example.com", Phone = "9876543210", Address = "456 Elm St", CompanyName = "XYZ Corp", Notes = "VIP customer", Tags = new List<string> { "VIP" } });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 customerForm = new Form2();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                customers.Add(customerForm.Customer);
                RefreshDataGridView();
                AddCustomerReminders(customerForm.Customer);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];
                Form2 customerForm = new Form2(selectedCustomer);
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    customers[selectedIndex] = customerForm.Customer;
                    RefreshDataGridView();
                    UpdateCustomerReminders(customerForm.Customer);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                RemoveCustomerReminders(customers[selectedIndex]);
                customers.RemoveAt(selectedIndex);
                RefreshDataGridView();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Customer Data";
            saveFileDialog.FileName = "customers.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;

                using (var writer = new StreamWriter(exportFilePath))
                {
                    writer.WriteLine("Name,Email,Phone,Address,CompanyName,Notes,Tags");
                    foreach (var customer in customers)
                    {
                        string name = customer.Name ?? "";
                        string email = customer.Email ?? "";
                        string phone = customer.Phone ?? "";
                        string address = customer.Address ?? "";
                        string companyName = customer.CompanyName ?? "";
                        string notes = customer.Notes ?? "";
                        string tags = customer.Tags != null ? string.Join(",", customer.Tags) : "";

                        writer.WriteLine($"{name},{email},{phone},{address},{companyName},{notes},{tags}");
                    }
                }

                MessageBox.Show($"Customer data exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string sortingCriteria = null;
            if (rbSortByName.Checked)
                sortingCriteria = "Name";
            else if (rbSortByEmail.Checked)
                sortingCriteria = "Email";
            else if (rbSortByPhone.Checked)
                sortingCriteria = "Phone";

            if (!string.IsNullOrEmpty(sortingCriteria))
            {
                List<Customer> sortedCustomers = new List<Customer>();
                switch (sortingCriteria)
                {
                    case "Name":
                        sortedCustomers = customers.OrderBy(c => c.Name).ToList();
                        break;
                    case "Email":
                        sortedCustomers = customers.OrderBy(c => c.Email).ToList();
                        break;
                    case "Phone":
                        sortedCustomers = customers.OrderBy(c => c.Phone).ToList();
                        break;
                }
                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = sortedCustomers;
            }
        }

        private void RefreshDataGridView()
        {
            dataGridViewCustomers.DataSource = null;
            dataGridViewCustomers.DataSource = customers;
            dataGridViewCustomers.AutoResizeColumns();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            List<Customer> filteredCustomers = customers.Where(c =>
                c.Name.ToLower().Contains(searchText) ||
                c.Email.ToLower().Contains(searchText) ||
                c.Phone.ToLower().Contains(searchText) ||
                c.Address.ToLower().Contains(searchText) ||
                c.CompanyName.ToLower().Contains(searchText) ||
                c.Notes.ToLower().Contains(searchText) ||
                c.Tags.Any(t => t.ToLower().Contains(searchText))
            ).ToList();

            dataGridViewCustomers.DataSource = null;
            dataGridViewCustomers.DataSource = filteredCustomers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 1)
            {
                StringBuilder detailsBuilder = new StringBuilder();

                foreach (DataGridViewRow row in dataGridViewCustomers.SelectedRows)
                {
                    Customer selectedCustomer = row.DataBoundItem as Customer;
                    detailsBuilder.AppendLine($"Name: {selectedCustomer.Name}");
                    detailsBuilder.AppendLine($"Email: {selectedCustomer.Email}");
                    detailsBuilder.AppendLine($"Phone: {selectedCustomer.Phone}");
                    detailsBuilder.AppendLine($"Address: {selectedCustomer.Address}");
                    detailsBuilder.AppendLine($"Company Name: {selectedCustomer.CompanyName}");
                    detailsBuilder.AppendLine($"Notes: {selectedCustomer.Notes}");
                    detailsBuilder.AppendLine($"Tags: {string.Join(", ", selectedCustomer.Tags)}");
                    detailsBuilder.AppendLine();
                }

                MultipleCustomerDetailsForm detailsForm = new MultipleCustomerDetailsForm();
                detailsForm.DisplayCustomerDetails(detailsBuilder.ToString());
                detailsForm.ShowDialog();
            }
            else if (dataGridViewCustomers.SelectedRows.Count == 1)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                CustomerDetailsForm customerForm = new CustomerDetailsForm(customers[selectedIndex]); // Fix here
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    customers[selectedIndex] = customerForm.Customer;
                    RefreshDataGridView();
                    UpdateCustomerReminders(customerForm.Customer);
                }
            }
            else
            {
                MessageBox.Show("Please select at least one customer.", "No Customers Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void AddCustomerReminders(Customer customer)
        {
            AddReminderForm addReminderForm = new AddReminderForm(customer);
            if (addReminderForm.ShowDialog() == DialogResult.OK)
            {
                Reminder reminder = addReminderForm.Reminder;
                reminder.AssociatedCustomer = customer;
                reminders.Add(reminder);
                RefreshDataGridView();
                MessageBox.Show("Reminder added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateCustomerReminders(Customer customer)
        {

        }

        private void RemoveCustomerReminders(Customer customer)
        {
            reminders.RemoveAll(r => r.AssociatedCustomer == customer);
        }

        private void btnViewReminder_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];

                var customerReminders = reminders.Where(r => r.AssociatedCustomer == selectedCustomer).ToList();

                if (customerReminders.Count > 0)
                {
                    string reminderDetails = "Reminders for " + selectedCustomer.Name + ":\n";
                    foreach (var reminder in customerReminders)
                    {
                        reminderDetails += $"Description: {reminder.Description}, Due Date: {reminder.DueDate}\n";
                    }

                    MessageBox.Show(reminderDetails, "Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No reminders found for the selected customer.", "No Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Reminder Data";
            saveFileDialog.FileName = "reminders.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string exportFilePath = saveFileDialog.FileName;

                using (var writer = new StreamWriter(exportFilePath))
                {
                    writer.WriteLine("Customer Name,Description,Due Date,Priority,Category");
                    foreach (var reminder in reminders)
                    {
                        string customerName = reminder.AssociatedCustomer.Name ?? "";
                        string description = reminder.Description ?? "";
                        string dueDate = reminder.DueDate.ToString() ?? "";
                        string priority = reminder.Priority ?? "";
                        string category = reminder.Category ?? "";

                        writer.WriteLine($"{customerName},{description},{dueDate},{priority},{category}");
                    }
                }

                MessageBox.Show($"Reminder data exported successfully to:\n{exportFilePath}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];

                StringBuilder transactionDetails = new StringBuilder();
                transactionDetails.AppendLine($"Transaction History for {selectedCustomer.Name}:");

                foreach (Transaction transaction in selectedCustomer.Transactions)
                {
                    transactionDetails.AppendLine($"Date: {transaction.TransactionDate}, Amount: {transaction.Transactionn}, Description: {transaction.Descriptionn}");
                }

                MessageBox.Show(transactionDetails.ToString(), "Transaction History", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];

                TransactionReminderForm reminderForm = new TransactionReminderForm(selectedCustomer);
                reminderForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];

                TransactionForm transactionForm = new TransactionForm();
                if (transactionForm.ShowDialog() == DialogResult.OK)
                {
                    decimal amount = transactionForm.TransactionAmount;
                    string description = transactionForm.TransactionDescription;
                    DateTime transactionDate = transactionForm.TransactionDate;

                    Transaction transaction = new Transaction(transactionDate, amount, description, "Sample category", "Sample currency");
                    selectedCustomer.Transactions.Add(transaction);
                    MessageBox.Show("Transaction completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChatForm();
        }

        private void OpenChatForm()
        {
            ChatForm chatForm = new ChatForm();
            chatForm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string CompanyName { get; set; }
    public string Notes { get; set; }
    public List<string> Tags { get; set; }
    public List<Transaction> Transactions { get; set; }

    public Customer()
    {
        Transactions = new List<Transaction>();
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Reminder
{
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Customer AssociatedCustomer { get; set; }
    public string Priority { get; set; }
    public string Category { get; set; }
    public DateTime ReminderTime { get; set; }
}

public class Transaction
{
    public DateTime TransactionDate { get; set; }
    public decimal Transactionn { get; set; }
    public string Descriptionn { get; set; }
    public string Category { get; set; }
    public string Currency { get; set; }

    public Transaction(DateTime transactionDate, decimal Amount, string description, string category, string currency)
    {
        TransactionDate = transactionDate;
        Transactionn = Amount;
        Descriptionn = description;
        Category = category;
        Currency = currency;
    }
}

public class Analytics
{
    public Dictionary<DateTime, int> SalesData { get; set; }

    public void AnalyzeSalesData(List<Customer> customers)
    { 

    }
}
