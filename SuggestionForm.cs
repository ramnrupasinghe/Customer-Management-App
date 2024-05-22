using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private Dictionary<string, string> ruleDetails;

        public SuggestionForm(List<string> rules)
        {
            InitializeComponent();
            suggestedRules = rules;
            PopulateSuggestions();
            InitializeRuleDetails();
        }

        private void PopulateSuggestions()
        {
            foreach (var rule in suggestedRules)
            {
                listBoxSuggestions.Items.Add(rule);
            }
        }

        private void InitializeRuleDetails()
        {
            // Initialize rule details for demonstration purposes
            ruleDetails = new Dictionary<string, string>();
            foreach (var rule in suggestedRules)
            {
                ruleDetails[rule] = "Details about " + rule; // Placeholder for real details
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
            if (listBoxSuggestions.SelectedIndex != -1)
            {
                string selectedRule = listBoxSuggestions.SelectedItem.ToString();
                lblRuleDetails.Text = ruleDetails[selectedRule];
            }
        }

        // Highlight suggestion feature
        private void HighlightSuggestions(string keyword)
        {
            foreach (var item in listBoxSuggestions.Items)
            {
                if (item.ToString().Contains(keyword))
                {
                    listBoxSuggestions.SelectedItem = item;
                    listBoxSuggestions.Focus();
                    break;
                }
            }
        }

        // Sort suggestion
        private void SortSuggestions()
        {
            listBoxSuggestions.Sorted = true;
        }

        // Filter the suggestions
        private void FilterSuggestions(string filter)
        {
            listBoxSuggestions.Items.Clear();
            foreach (var rule in suggestedRules)
            {
                if (rule.ToLower().Contains(filter.ToLower()))
                {
                    listBoxSuggestions.Items.Add(rule);
                }
            }
        }

        // Count suggestion feature
        private int CountSuggestions()
        {
            return listBoxSuggestions.Items.Count;
        }

        // New feature , Auto-Suggest Based on Typing
        private void txtAutoSuggest_TextChanged(object sender, EventArgs e)
        {
            FilterSuggestions(txtAutoSuggest.Text);
        }

        // New feature ,Display Suggestion Details
        private void listBoxSuggestions_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxSuggestions.SelectedIndex != -1)
            {
                string selectedRule = listBoxSuggestions.SelectedItem.ToString();
                lblRuleDetails.Text = ruleDetails[selectedRule];
            }
        }
    }
}
