namespace CustomerManagementApp
{
    partial class SnoozeDurationForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectDuration = new System.Windows.Forms.Label();
            this.comboBoxUnits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCustomLabel = new System.Windows.Forms.TextBox();
            this.lblCustomLabel = new System.Windows.Forms.Label();
            this.txtCustomMessage = new System.Windows.Forms.TextBox();
            this.lblCustomMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
          
            this.numericUpDown1.Location = new System.Drawing.Point(106, 52);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
          
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(12, 410);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(266, 410);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
           
            this.lblSelectDuration.AutoSize = true;
            this.lblSelectDuration.Location = new System.Drawing.Point(109, 18);
            this.lblSelectDuration.Name = "lblSelectDuration";
            this.lblSelectDuration.Size = new System.Drawing.Size(147, 16);
            this.lblSelectDuration.TabIndex = 2;
            this.lblSelectDuration.Text = "Select Snooze Duration";
          
            this.comboBoxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days"});
            this.comboBoxUnits.Location = new System.Drawing.Point(106, 109);
            this.comboBoxUnits.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(150, 24);
            this.comboBoxUnits.TabIndex = 3;
            this.comboBoxUnits.SelectedIndexChanged += new System.EventHandler(this.comboBoxUnits_SelectedIndexChanged);
            
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Duration Unit";
             
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(164)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(142, 410);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboBoxPriority.Location = new System.Drawing.Point(106, 177);
            this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(150, 24);
            this.comboBoxPriority.TabIndex = 6;
            this.comboBoxPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxPriority_SelectedIndexChanged);
            
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Priority";
           
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(164)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(40, 478);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Repeat";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(164)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(229, 478);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 9;
            this.button3.Text = "Sound";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
           
            this.txtCustomLabel.Location = new System.Drawing.Point(106, 247);
            this.txtCustomLabel.Name = "txtCustomLabel";
            this.txtCustomLabel.Size = new System.Drawing.Size(150, 22);
            this.txtCustomLabel.TabIndex = 10;
            this.txtCustomLabel.TextChanged += new System.EventHandler(this.txtCustomLabel_TextChanged);
         
            this.lblCustomLabel.AutoSize = true;
            this.lblCustomLabel.Location = new System.Drawing.Point(139, 211);
            this.lblCustomLabel.Name = "lblCustomLabel";
            this.lblCustomLabel.Size = new System.Drawing.Size(89, 16);
            this.lblCustomLabel.TabIndex = 11;
            this.lblCustomLabel.Text = "Custom Label";
           
            this.txtCustomMessage.Location = new System.Drawing.Point(12, 335);
            this.txtCustomMessage.Multiline = true;
            this.txtCustomMessage.Name = "txtCustomMessage";
            this.txtCustomMessage.Size = new System.Drawing.Size(354, 50);
            this.txtCustomMessage.TabIndex = 12;
            this.txtCustomMessage.TextChanged += new System.EventHandler(this.txtCustomMessage_TextChanged);
           
            this.lblCustomMessage.AutoSize = true;
            this.lblCustomMessage.Location = new System.Drawing.Point(130, 301);
            this.lblCustomMessage.Name = "lblCustomMessage";
            this.lblCustomMessage.Size = new System.Drawing.Size(112, 16);
            this.lblCustomMessage.TabIndex = 13;
            this.lblCustomMessage.Text = "Custom Message";
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 550);
            this.Controls.Add(this.lblCustomMessage);
            this.Controls.Add(this.txtCustomMessage);
            this.Controls.Add(this.lblCustomLabel);
            this.Controls.Add(this.txtCustomLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUnits);
            this.Controls.Add(this.lblSelectDuration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnoozeDurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snooze Duration";
            this.Load += new System.EventHandler(this.SnoozeDurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectDuration;
        private System.Windows.Forms.ComboBox comboBoxUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCustomLabel;
        private System.Windows.Forms.Label lblCustomLabel;
        private System.Windows.Forms.TextBox txtCustomMessage;
        private System.Windows.Forms.Label lblCustomMessage;
    }
}
