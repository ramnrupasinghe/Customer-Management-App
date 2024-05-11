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
            DisableSelectButtonIfNoRecipientSelected();
        }

        private void PopulateContacts(List<string> contactsList)
        {
            lstContacts.Items.AddRange(contactsList.ToArray());
        }

        private void DisableSelectButtonIfNoRecipientSelected()
        {
            btnSelect.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectRecipient();
        }

        private void SelectRecipient()
        {
            if (lstContacts.SelectedItem != null)
            {
                SelectedRecipient = lstContacts.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a recipient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSelectButtonIfRecipientSelected();
        }

        private void EnableSelectButtonIfRecipientSelected()
        {
            btnSelect.Enabled = lstContacts.SelectedItem != null;
        }

        private void SelectRecipientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
