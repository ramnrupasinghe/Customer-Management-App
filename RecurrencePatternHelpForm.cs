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
                                "Choose between daily, weekly, or monthly recurrence options to tailor your scheduling " +
                                "preferences according to your needs.\n\nSimply click on the radio button corresponding " +
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
    }
}
