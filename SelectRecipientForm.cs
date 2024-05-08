using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class SelectRecipientForm : Form
    {
        public string SelectedRecipient { get; private set; }

        public SelectRecipientForm(List<string> contactsList)
        {
            InitializeComponent();
            PopulateContacts(contactsList);
        }

        private void PopulateContacts(List<string> contactsList)
        {
            foreach (string contact in contactsList)
            {
                lstContacts.Items.Add(contact);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedItem != null)
            {
                SelectedRecipient = lstContacts.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a recipient.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
