using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class SuggestionForm : Form
    {
        public string SelectedRule { get; private set; }

        private List<string> suggestedRules;

        public SuggestionForm(List<string> rules)
        {
            InitializeComponent();
            suggestedRules = rules;
            PopulateSuggestions();
        }

        private void PopulateSuggestions()
        {
            foreach (var rule in suggestedRules)
            {
                listBoxSuggestions.Items.Add(rule);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (listBoxSuggestions.SelectedIndex != -1)
            {
                SelectedRule = listBoxSuggestions.SelectedItem.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a rule from the list.", "No Rule Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedRule = null;
            this.Close();
        }

        private void SuggestionForm_Load(object sender, EventArgs e)
        {
           
        }

        private void listBoxSuggestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
