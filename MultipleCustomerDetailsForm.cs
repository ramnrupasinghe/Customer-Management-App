using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class MultipleCustomerDetailsForm : Form
    {
        private Panel[] deletedPanels; 
        private Button btnEdit;

        public MultipleCustomerDetailsForm()
        {
            InitializeComponent();
            deletedPanels = null; 
            InitializeEditButton();
        }

        private void InitializeEditButton()
        {
            btnEdit = new Button();
            btnEdit.Text = "Edit";
            btnEdit.Location = new Point(250, 297); 
            btnEdit.Click += button1_Click_1;
            this.Controls.Add(btnEdit);
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
                    using (var writer = new System.IO.StreamWriter(filePath))
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
            EditCustomerForm editForm = new EditCustomerForm();
            editForm.ShowDialog();

           
            if (editForm.DialogResult == DialogResult.OK)
            {
                UpdateCustomerDetails(editForm.CustomerDetails);
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

        private void MultipleCustomerDetailsForm_Load(object sender, EventArgs e)
        {
            
            string sampleDetails = "Customer 1 Details" + Environment.NewLine + "Customer 2 Details" + Environment.NewLine + "Customer 3 Details";
            DisplayCustomerDetails(sampleDetails);
        }
    }
}
