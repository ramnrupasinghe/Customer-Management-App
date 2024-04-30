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

        public RecurrencePatternHelpForm()
        {
            InitializeComponent();
            DisplayWelcomeMessage();
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

    }
}
