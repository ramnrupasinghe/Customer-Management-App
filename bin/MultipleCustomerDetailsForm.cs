using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class MultipleCustomerDetailsForm : Form
    {
        private Panel[] deletedPanels;
        private Button btnEdit;
        private Button btnImport;
        private Button btnSort;
        private TextBox txtSearch;
        private ComboBox cmbSortOptions;

        public MultipleCustomerDetailsForm()
        {
            InitializeComponent();
            deletedPanels = null;
            InitializeEditButton();
            InitializeImportButton();
            InitializeSearchTextBox();
            InitializeSortButton();
            InitializeSortComboBox();
        }

        private void InitializeSortComboBox()
        {
            cmbSortOptions = new ComboBox();
            cmbSortOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortOptions.Items.AddRange(new object[] { "Name", "Email", "Phone" });
            cmbSortOptions.SelectedIndex = 0;
            cmbSortOptions.Location = new Point(10, 330);
            cmbSortOptions.Size = new Size(150, 23);
            cmbSortOptions.SelectedIndexChanged += cmbSortOptions_SelectedIndexChanged;
            this.Controls.Add(cmbSortOptions);
        }

        private void InitializeEditButton()
        {
            btnEdit = new Button();
            btnEdit.Text = "Search";
            btnEdit.Location = new Point(225, 297);
            btnEdit.Click += button1_Click_1;
            this.Controls.Add(btnEdit);
        }

        private void InitializeImportButton()
        {
            btnImport = new Button();
            btnImport.Text = "Import";
            btnImport.Location = new Point(320, 297);
            btnImport.Click += btnImport_Click;
            this.Controls.Add(btnImport);
        }

        private void InitializeSearchTextBox()
        {
            txtSearch = new TextBox();
            txtSearch.Text = "Search by name...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.GotFocus += TxtSearch_GotFocus;
            txtSearch.LostFocus += TxtSearch_LostFocus;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Location = new Point(10, 297);
            txtSearch.Size = new Size(200, 23);
            this.Controls.Add(txtSearch);
        }

        private void InitializeSortButton()
        {
            btnSort = new Button();
            btnSort.Text = "Sort";
            btnSort.Location = new Point(170, 330);
            btnSort.Click += btnSort_Click;
            this.Controls.Add(btnSort);
        }

        private void TxtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search by name...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void cmbSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbSortOptions = (ComboBox)sender;
            string selectedOption = cmbSortOptions.SelectedItem.ToString();

            SortCustomerDetailsByCriterion(selectedOption);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        string customerDetail = textBox.Text.ToLower();
                        if (customerDetail.Contains(searchText))
                            control.Visible = true;
                        else
                            control.Visible = false;
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Customer Details";
            saveFileDialog.FileName = "customer_details.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is Panel && control.Name == "dynamicPanel")
                            {
                                foreach (Control innerControl in control.Controls)
                                {
                                    if (innerControl is TextBox)
                                    {
                                        writer.WriteLine(((TextBox)innerControl).Text);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while saving details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Customer Details";
            saveFileDialog.FileName = "customer_details.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (var writer = new StreamWriter(filePath))
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is Panel && control.Name == "dynamicPanel")
                            {
                                foreach (Control innerControl in control.Controls)
                                {
                                    if (innerControl is TextBox)
                                    {
                                        writer.WriteLine(((TextBox)innerControl).Text);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while saving details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected customer details?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                deletedPanels = this.Controls.Find("dynamicPanel", true) as Panel[];

                foreach (Control control in this.Controls)
                {
                    if (control is Panel && control.Name == "dynamicPanel")
                    {
                        this.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                MessageBox.Show("Selected customer details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text != "Search by name...")
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                foreach (Control control in this.Controls)
                {
                    if (control is Panel && control.Name == "dynamicPanel" && control.Visible)
                    {
                        TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                        if (textBox != null)
                        {
                            string customerDetail = textBox.Text.ToLower();
                            if (customerDetail.Contains(searchText))
                            {
                                EditCustomerForm editForm = new EditCustomerForm();
                                editForm.CustomerDetails = textBox.Text;
                                editForm.ShowDialog();

                                if (editForm.DialogResult == DialogResult.OK)
                                {
                                    UpdateCustomerDetails(editForm.CustomerDetails);
                                }
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("No matching customer found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a search query first.", "No Search Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateCustomerDetails(string updatedDetails)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }

            DisplayCustomerDetails(updatedDetails);
        }

        public void DisplayCustomerDetails(string details)
        {
            string[] customerDetails = details.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int panelWidth = 300;
            int panelHeight = 100;
            int panelMargin = 10;
            int xPos = 10;
            int yPos = 10;

            foreach (string customerDetail in customerDetails)
            {
                Panel panel = new Panel();
                panel.Size = new Size(panelWidth, panelHeight);
                panel.Location = new Point(xPos, yPos);
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Name = "dynamicPanel";
                this.Controls.Add(panel);

                TextBox textBox = new TextBox();
                textBox.Multiline = true;
                textBox.ReadOnly = true;
                textBox.Text = customerDetail;
                textBox.Dock = DockStyle.Fill;
                textBox.BorderStyle = BorderStyle.None;
                textBox.BackColor = Color.White;
                panel.Controls.Add(textBox);

                yPos += panelHeight + panelMargin;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string[] sortOptions = { "Name", "Email", "Phone" };

            DialogResult result = MessageBox.Show("Select a sorting criterion:", "Sort by", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                string selectedOption = cmbSortOptions.SelectedItem.ToString();

                SortCustomerDetailsByCriterion(selectedOption);
            }
        }

        private void SortCustomerDetailsByCriterion(string criterion)
        {
            List<string> sortedDetails = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name == "dynamicPanel")
                {
                    TextBox textBox = control.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null)
                    {
                        sortedDetails.Add(textBox.Text);
                    }
                }
            }

            switch (criterion)
            {
                case "Name":
                    sortedDetails.Sort((x, y) => string.Compare(x.Split('\n')[0], y.Split('\n')[0]));
                    break;
                case "Email":
                    sortedDetails.Sort((x, y) => string.Compare(x.Split('\n')[1], y.Split('\n')[1]));
                    break;
                case "Phone":
                    sortedDetails.Sort((x, y) => string.Compare(x.Split('\n')[2], y.Split('\n')[2]));
                    break;
            }

            UpdateCustomerDetails(string.Join(Environment.NewLine + Environment.NewLine, sortedDetails));
        }

        private void MultipleCustomerDetailsForm_Load(object sender, EventArgs e)
        {
            string sampleDetails = "Customer 1 Details" + Environment.NewLine + "Customer 2 Details" + Environment.NewLine + "Customer 3 Details";
            DisplayCustomerDetails(sampleDetails);
        }
    }
}
