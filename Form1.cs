using System;
using System.Collections.Generic;
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
            RefreshDataGridView();
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

        private void RefreshDataGridView()
        {
            dataGridViewCustomers.DataSource = null;
            dataGridViewCustomers.DataSource = customers;
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

        public override string ToString()
        {
            return Name;
        }
    }
}
