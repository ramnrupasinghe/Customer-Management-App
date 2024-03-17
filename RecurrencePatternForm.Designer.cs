namespace CustomerManagementApp
{
    partial class RecurrencePatternForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBoxRecurrencePattern = new System.Windows.Forms.GroupBox();
            this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekly = new System.Windows.Forms.RadioButton();
            this.radioButtonDaily = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBoxRecurrencePattern.SuspendLayout();
            this.SuspendLayout();
           
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonMonthly);
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonWeekly);
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonDaily);
            this.groupBoxRecurrencePattern.Location = new System.Drawing.Point(16, 15);
            this.groupBoxRecurrencePattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRecurrencePattern.Name = "groupBoxRecurrencePattern";
            this.groupBoxRecurrencePattern.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRecurrencePattern.Size = new System.Drawing.Size(267, 123);
            this.groupBoxRecurrencePattern.TabIndex = 0;
            this.groupBoxRecurrencePattern.TabStop = false;
            this.groupBoxRecurrencePattern.Text = "Recurrence Pattern";
            this.groupBoxRecurrencePattern.Enter += new System.EventHandler(this.groupBoxRecurrencePattern_Enter);
           
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Location = new System.Drawing.Point(8, 80);
            this.radioButtonMonthly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(74, 20);
            this.radioButtonMonthly.TabIndex = 2;
            this.radioButtonMonthly.TabStop = true;
            this.radioButtonMonthly.Text = "Monthly";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            
           
            this.radioButtonWeekly.AutoSize = true;
            this.radioButtonWeekly.Location = new System.Drawing.Point(8, 52);
            this.radioButtonWeekly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonWeekly.Name = "radioButtonWeekly";
            this.radioButtonWeekly.Size = new System.Drawing.Size(74, 20);
            this.radioButtonWeekly.TabIndex = 1;
            this.radioButtonWeekly.TabStop = true;
            this.radioButtonWeekly.Text = "Weekly";
            this.radioButtonWeekly.UseVisualStyleBackColor = true;
            
            this.radioButtonDaily.AutoSize = true;
            this.radioButtonDaily.Location = new System.Drawing.Point(8, 23);
            this.radioButtonDaily.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonDaily.Name = "radioButtonDaily";
            this.radioButtonDaily.Size = new System.Drawing.Size(59, 20);
            this.radioButtonDaily.TabIndex = 0;
            this.radioButtonDaily.TabStop = true;
            this.radioButtonDaily.Text = "Daily";
            this.radioButtonDaily.UseVisualStyleBackColor = true;
            
            this.btnCancel.Location = new System.Drawing.Point(183, 145);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.btnOK.Location = new System.Drawing.Point(75, 145);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
           
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 188);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxRecurrencePattern);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecurrencePatternForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recurrence Pattern";
            this.groupBoxRecurrencePattern.ResumeLayout(false);
            this.groupBoxRecurrencePattern.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRecurrencePattern;
        private System.Windows.Forms.RadioButton radioButtonMonthly;
        private System.Windows.Forms.RadioButton radioButtonWeekly;
        private System.Windows.Forms.RadioButton radioButtonDaily;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
