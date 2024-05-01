using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class AddReminderForm : Form
    {
        public RReminder Reminder { get; private set; }
        private Customer customer;

        private const int MaxDescriptionLength = 100;

        private CheckBox chkRecurring;
        private ComboBox cbRecurrenceFrequency;
        private DateTimePicker datePickerEndDate;
        private CheckBox chkSetEndDate;
        private ColorDialog colorDialog;
        private Button btnChooseColor;
        private Panel colorPanel;
        private Button btnPreviewAttachments;
        private Button btnCustomizeColor;

        private List<string> attachedFiles = new List<string>();
        private List<string> attachedUrls = new List<string>();

        public AddReminderForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblCustomerName.Text = $"Adding reminder for: {customer.Name}";
            datePickerDueDate.MinDate = DateTime.Today;

            cbPriority.Items.AddRange(new string[] { "Low", "Medium", "High" });
            cbCategory.Items.AddRange(new string[] { "Work", "Personal", "Shopping" });

            timePickerReminderTime.Value = DateTime.Now.AddHours(1);

            chkRecurring = new CheckBox();
            chkRecurring.Text = "Recurring";
            chkRecurring.AutoSize = true;
            chkRecurring.Location = new System.Drawing.Point(20, 220);
            chkRecurring.CheckedChanged += ChkRecurring_CheckedChanged;
            Controls.Add(chkRecurring);

            cbRecurrenceFrequency = new ComboBox();
            cbRecurrenceFrequency.Items.AddRange(new string[] { "Daily", "Weekly", "Monthly", "Yearly" });
            cbRecurrenceFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRecurrenceFrequency.Location = new System.Drawing.Point(150, 220);
            cbRecurrenceFrequency.Enabled = false;
            Controls.Add(cbRecurrenceFrequency);

            chkSetEndDate = new CheckBox();
            chkSetEndDate.Text = "Set End Date";
            chkSetEndDate.AutoSize = true;
            chkSetEndDate.Location = new System.Drawing.Point(20, 250);
            chkSetEndDate.CheckedChanged += ChkSetEndDate_CheckedChanged;
            chkSetEndDate.Enabled = false;
            Controls.Add(chkSetEndDate);

            datePickerEndDate = new DateTimePicker();
            datePickerEndDate.Location = new System.Drawing.Point(150, 250);
            datePickerEndDate.Enabled = false;
            Controls.Add(datePickerEndDate);

            colorDialog = new ColorDialog();
            btnChooseColor = new Button();
            btnChooseColor.Text = "Choose Color";
            btnChooseColor.Location = new Point(20, 280);
            btnChooseColor.Click += BtnChooseColor_Click;
            Controls.Add(btnChooseColor);

            colorPanel = new Panel();
            colorPanel.BackColor = Color.White;
            colorPanel.Size = new Size(50, 20);
            colorPanel.Location = new Point(150, 280);
            Controls.Add(colorPanel);

           
            btnPreviewAttachments = new Button();
            btnPreviewAttachments.Text = "Preview Attachments";
            btnPreviewAttachments.Location = new Point(150, 310);
            btnPreviewAttachments.Click += BtnPreviewAttachments_Click;
            Controls.Add(btnPreviewAttachments);

           
            btnCustomizeColor = new Button();
            btnCustomizeColor.Text = "Customize Color";
            btnCustomizeColor.Location = new Point(20, 310);
            btnCustomizeColor.Click += BtnCustomizeColor_Click;
            Controls.Add(btnCustomizeColor);
        }

        private void ChkRecurring_CheckedChanged(object sender, EventArgs e)
        {
            cbRecurrenceFrequency.Enabled = chkRecurring.Checked;
            chkSetEndDate.Enabled = chkRecurring.Checked;
            if (!chkRecurring.Checked)
            {
                chkSetEndDate.Checked = false;
                datePickerEndDate.Enabled = false;
            }
        }

        private void ChkSetEndDate_CheckedChanged(object sender, EventArgs e)
        {
            datePickerEndDate.Enabled = chkSetEndDate.Checked;
        }

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                colorPanel.BackColor = colorDialog.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Description cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (description.Length > MaxDescriptionLength)
            {
                MessageBox.Show($"Description length cannot exceed {MaxDescriptionLength} characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string priority = cbPriority.SelectedItem.ToString();
            string category = cbCategory.SelectedItem.ToString();

            bool isRecurring = chkRecurring.Checked;
            RecurrenceFrequency recurrenceFrequency = RecurrenceFrequency.None;
            DateTime? endDate = null;

            if (isRecurring)
            {
                if (cbRecurrenceFrequency.SelectedItem == null)
                {
                    MessageBox.Show("Please select a recurrence frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Enum.TryParse(cbRecurrenceFrequency.SelectedItem.ToString(), out recurrenceFrequency);
                }

                endDate = chkSetEndDate.Checked ? (DateTime?)datePickerEndDate.Value : null;
            }

            Color reminderColor = colorPanel.BackColor;

            Reminder = new RReminder
            {
                Description = description,
                DueDate = datePickerDueDate.Value,
                AssociatedCustomer = customer,
                Priority = priority,
                Category = category,
                ReminderTime = timePickerReminderTime.Value,
                IsRecurring = isRecurring,
                RecurrenceFrequency = recurrenceFrequency,
                EndDate = endDate,
                AttachedFiles = attachedFiles,
                AttachedUrls = attachedUrls,
                RecurrencePattern = new RecurrencePattern(),
              

            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateCharacterCounter();
        }

        private void UpdateCharacterCounter()
        {
            int remainingCharacters = MaxDescriptionLength - txtDescription.TextLength;
            lblCharacterCounter.Text = $"{remainingCharacters} characters remaining";
        }

        private void timePickerReminderTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnPreviewAttachments_Click(object sender, EventArgs e)
        {
          
            var attachmentInfo = new System.Text.StringBuilder();

       
            attachmentInfo.AppendLine("Attached Files:");
            foreach (var file in attachedFiles)
            {
                attachmentInfo.AppendLine(file);
            }

        
            attachmentInfo.AppendLine("\nAttached URLs:");
            foreach (var url in attachedUrls)
            {
                attachmentInfo.AppendLine(url);
            }

        
            MessageBox.Show(attachmentInfo.ToString(), "Attachment Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void BtnCustomizeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                colorPanel.BackColor = colorDialog.Color;
            }
        }

        private void datePickerDueDate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void AddReminderForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    attachedFiles.Add(file);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = Microsoft.VisualBasic.Interaction.InputBox("Please enter the URL:", "Attach URL", "");
            if (!string.IsNullOrEmpty(url))
            {
                attachedUrls.Add(url);
            }
        }
    }
}
