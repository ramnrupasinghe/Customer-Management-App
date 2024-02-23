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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInitialCustomerData();
            RefreshDataGridView();
        }

        private void LoadInitialCustomerData()
        {
            customers.Add(new Customer { Name = "John Doe", Email = "john@example.com", Phone = "1234567890", Address = "123 Main St", CompanyName = "ABC Inc.", Notes = "Regular customer" });
            customers.Add(new Customer { Name = "Jane Smith", Email = "jane@example.com", Phone = "9876543210", Address = "456 Elm St", CompanyName = "XYZ Corp", Notes = "VIP customer" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 customerForm = new Form2();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                customers.Add(customerForm.Customer);
                RefreshDataGridView();
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
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                customers.RemoveAt(selectedIndex);
                RefreshDataGridView();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter("customers.csv"))
            {
                writer.WriteLine("Name,Email,Phone,Address,CompanyName,Notes");
                foreach (var customer in customers)
                {
                    writer.WriteLine($"{customer.Name},{customer.Email},{customer.Phone},{customer.Address},{customer.CompanyName},{customer.Notes}");
                }
            }

            MessageBox.Show("Customer data exported successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                c.Notes.ToLower().Contains(searchText)
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

        private void dataGridViewCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        public override string ToString()
        {
            return Name;
        }
    }
}
