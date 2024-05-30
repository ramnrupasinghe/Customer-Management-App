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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxRecurrencePattern.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRecurrencePattern
            // 
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonMonthly);
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonWeekly);
            this.groupBoxRecurrencePattern.Controls.Add(this.radioButtonDaily);
            this.groupBoxRecurrencePattern.Location = new System.Drawing.Point(16, 15);
            this.groupBoxRecurrencePattern.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxRecurrencePattern.Name = "groupBoxRecurrencePattern";
            this.groupBoxRecurrencePattern.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxRecurrencePattern.Size = new System.Drawing.Size(267, 123);
            this.groupBoxRecurrencePattern.TabIndex = 0;
            this.groupBoxRecurrencePattern.TabStop = false;
            this.groupBoxRecurrencePattern.Text = "Recurrence Pattern";
            this.groupBoxRecurrencePattern.Enter += new System.EventHandler(this.groupBoxRecurrencePattern_Enter);
            // 
            // radioButtonMonthly
            // 
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Location = new System.Drawing.Point(8, 80);
            this.radioButtonMonthly.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(74, 20);
            this.radioButtonMonthly.TabIndex = 2;
            this.radioButtonMonthly.TabStop = true;
            this.radioButtonMonthly.Text = "Monthly";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            // 
            // radioButtonWeekly
            // 
            this.radioButtonWeekly.AutoSize = true;
            this.radioButtonWeekly.Location = new System.Drawing.Point(8, 52);
            this.radioButtonWeekly.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonWeekly.Name = "radioButtonWeekly";
            this.radioButtonWeekly.Size = new System.Drawing.Size(74, 20);
            this.radioButtonWeekly.TabIndex = 1;
            this.radioButtonWeekly.TabStop = true;
            this.radioButtonWeekly.Text = "Weekly";
            this.radioButtonWeekly.UseVisualStyleBackColor = true;
            // 
            // radioButtonDaily
            // 
            this.radioButtonDaily.AutoSize = true;
            this.radioButtonDaily.Location = new System.Drawing.Point(8, 23);
            this.radioButtonDaily.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonDaily.Name = "radioButtonDaily";
            this.radioButtonDaily.Size = new System.Drawing.Size(59, 20);
            this.radioButtonDaily.TabIndex = 0;
            this.radioButtonDaily.TabStop = true;
            this.radioButtonDaily.Text = "Daily";
            this.radioButtonDaily.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 271);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 47);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(24, 146);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 48);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 216);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "Help";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 216);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 47);
            this.button3.TabIndex = 5;
            this.button3.Text = "Recurrence Exclusions";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // RecurrencePatternForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 331);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxRecurrencePattern);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecurrencePatternForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recurrence Pattern";
            this.Load += new System.EventHandler(this.RecurrencePatternForm_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
