using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];
                CustomerDetailsForm detailsForm = new CustomerDetailsForm(selectedCustomer);
                detailsForm.ShowDialog();
            }
        }

        private void AddCustomerReminders(Customer customer)
        {

        }

        private void UpdateCustomerReminders(Customer customer)
        {

        }

        private void RemoveCustomerReminders(Customer customer)
        {

        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnAddReminder_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                Customer selectedCustomer = customers[selectedIndex];

                AddReminderForm addReminderForm = new AddReminderForm(selectedCustomer);
                if (addReminderForm.ShowDialog() == DialogResult.OK)
                {
                    Reminder reminder = addReminderForm.Reminder;
                    reminders.Add(reminder);
                    MessageBox.Show("Reminder added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
    }

    public class Analytics
    {
        public Dictionary<DateTime, int> SalesData { get; set; }

        public void AnalyzeSalesData(List<Customer> customers)
        {

        }
    }
}
