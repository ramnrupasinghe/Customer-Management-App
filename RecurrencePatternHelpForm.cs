using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class RecurrencePatternHelpForm : Form
    {
        private Label lblRecurrencePattern;
        private Label lblPatternPreview;
        private Button btnClose;
        private Button btnCustomPattern;
        private Button btnPatternPreview;
        private TextBox txtRecurrenceRule;
        private Button btnValidateRule;
        private Button btnParseRule;
        private Button btnGenerateRule;
        private Button btnEditRule;
        private Button btnUndoRule;
        private Button btnSuggestRule;

        private Stack<string> ruleUndoStack;
        private List<string> suggestedRules;

        public RecurrencePatternHelpForm()
        {
            InitializeComponent();
            DisplayWelcomeMessage();
            ruleUndoStack = new Stack<string>();
            suggestedRules = new List<string>() { "RRULE:FREQ=DAILY;COUNT=5", "RRULE:FREQ=WEEKLY;COUNT=10", "RRULE:FREQ=MONTHLY;COUNT=3" };
        }

        private void DisplayWelcomeMessage()
        {
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Welcome to the Recurrence Pattern Selection Page! 📅\n\n" +
                                "In this page, you can effortlessly set the recurrence pattern for your activities. " +
                                "Choose between daily, weekly, monthly recurrence options, or create a custom pattern to tailor " +
                                "your scheduling preferences according to your needs.\n\nSimply click on the radio button corresponding " +
                                "to your desired recurrence pattern, and then hit the \"OK\" button to confirm your selection. " +
                                "If you're unsure about the available options or need further assistance, feel free to " +
                                "click on the \"Help\" button for guidance. \n\nAdditionally, if you ever want to start afresh " +
                                "and reset your selections, just click the \"Reset\" button to restore the form to its default state. " +
                                "Let's streamline your activity scheduling and organization together! 🔄💼";
            welcomeLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            welcomeLabel.AutoSize = false;
            welcomeLabel.Size = new Size(400, 300);
            welcomeLabel.Location = new Point(20, 20);
            welcomeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(welcomeLabel);
        }

        private void RecurrencePatternHelpForm_Load(object sender, EventArgs e)
        {
          
            txtRecurrenceRule.Text = "RRULE:FREQ=DAILY;COUNT=5";

         
            button3.Visible = false;

            suggestedRules.Add("RRULE:FREQ=WEEKLY;COUNT=10");
            suggestedRules.Add("RRULE:FREQ=MONTHLY;COUNT=3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatternPreviewForm patternPreviewForm = new PatternPreviewForm();
            patternPreviewForm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValidateRule_Click(object sender, EventArgs e)
        {
            string rule = txtRecurrenceRule.Text;
            if (IsValidRecurrenceRule(rule))
            {
                MessageBox.Show("Recurrence rule is valid!", "Validation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Recurrence rule is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidRecurrenceRule(string rule)
        {
            rule = rule.Trim();

            if (string.IsNullOrEmpty(rule))
                return false;

            if (!rule.StartsWith("RRULE:", StringComparison.OrdinalIgnoreCase))
                return false;

            string ruleValue = rule.Substring("RRULE:".Length);
            string[] ruleParts = ruleValue.Split(';');

            bool freqPresent = false;

            foreach (var part in ruleParts)
            {
                string[] keyValue = part.Split('=');

                if (keyValue.Length != 2)
                    return false;

                string key = keyValue[0].Trim().ToUpper();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "FREQ":
                        if (value != "SECONDLY" && value != "MINUTELY" && value != "HOURLY" &&
                            value != "DAILY" && value != "WEEKLY" && value != "MONTHLY" && value != "YEARLY")
                            return false;
                        freqPresent = true;
                        break;
                }
            }

            if (!freqPresent)
                return false;

            return true;
        }

        private void btnParseRule_Click(object sender, EventArgs e)
        {
            string rule = txtRecurrenceRule.Text;
            string parsedRule = ParseRecurrenceRule(rule);
            MessageBox.Show("Parsed Recurrence Rule:\n" + parsedRule, "Rule Parsing Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ParseRecurrenceRule(string rule)
        {
            rule = rule.Trim();

            if (!rule.StartsWith("RRULE:", StringComparison.OrdinalIgnoreCase))
                return "Invalid recurrence rule format.";

            string ruleValue = rule.Substring("RRULE:".Length);
            string[] ruleParts = ruleValue.Split(';');

            Dictionary<string, string> parsedComponents = new Dictionary<string, string>();

            foreach (var part in ruleParts)
            {
                string[] keyValue = part.Split('=');

                if (keyValue.Length != 2)
                    return "Invalid recurrence rule format.";

                string key = keyValue[0].Trim().ToUpper();
                string value = keyValue[1].Trim();

                parsedComponents[key] = value;
            }

            string parsedRule = "Recurrence Rule:";
            foreach (var kvp in parsedComponents)
            {
                parsedRule += $"\n{kvp.Key}: {kvp.Value}";
            }

            return parsedRule;
        }

        private void btnGenerateRule_Click(object sender, EventArgs e)
        {
            string generatedRule = GenerateRecurrenceRule();
            MessageBox.Show("Generated Recurrence Rule:\n" + generatedRule, "Rule Generation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateRecurrenceRule()
        {
            return "RRULE:FREQ=DAILY;COUNT=10";
        }

        private void btnEditRule_Click(object sender, EventArgs e)
        {
            if (txtRecurrenceRule.Enabled)
            {
                txtRecurrenceRule.Enabled = false;
                btnEditRule.Text = "Edit Rule";
            }
            else
            {
                txtRecurrenceRule.Enabled = true;
                btnEditRule.Text = "Finish Editing";
            }
        }

        private void btnUndoRule_Click(object sender, EventArgs e)
        {
            if (ruleUndoStack.Count > 0)
            {
                txtRecurrenceRule.Text = ruleUndoStack.Pop();
            }
        }

        private void btnSuggestRule_Click(object sender, EventArgs e)
        {
       
            SuggestionForm suggestionForm = new SuggestionForm(suggestedRules);
            suggestionForm.ShowDialog();
            if (suggestionForm.SelectedRule != null)
            {
                txtRecurrenceRule.Text = suggestionForm.SelectedRule;
            }
        }

        private void btnCustomPattern_Click(object sender, EventArgs e)
        {
            CustomPatternForm customPatternForm = new CustomPatternForm();
            customPatternForm.ShowDialog();
        }
    }
}
