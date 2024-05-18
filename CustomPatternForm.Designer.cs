namespace CustomerManagementApp
{
    partial class CustomPatternForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.txtHeaders = new System.Windows.Forms.TextBox();
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.buttonSave = new System.Windows.Forms.Button(); 
            this.SuspendLayout();
            
            this.txtPattern.Location = new System.Drawing.Point(12, 12);
            this.txtPattern.Multiline = true;
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(260, 80);
            this.txtPattern.TabIndex = 0;
           
            this.txtHeaders.Location = new System.Drawing.Point(12, 98);
            this.txtHeaders.Multiline = true;
            this.txtHeaders.Name = "txtHeaders";
            this.txtHeaders.Size = new System.Drawing.Size(260, 80);
            this.txtHeaders.TabIndex = 1;
           
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.ItemHeight = 16;
            this.listBoxMessages.Location = new System.Drawing.Point(12, 184);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(260, 132);
            this.listBoxMessages.TabIndex = 2;
            
            this.buttonSave.Location = new System.Drawing.Point(197, 324);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.btnSave_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.txtHeaders);
            this.Controls.Add(this.txtPattern);
            this.Name = "CustomPatternForm";
            this.Text = "Custom Pattern Form";
            this.Load += new System.EventHandler(this.CustomPatternForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.TextBox txtHeaders; 
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.Button buttonSave;
    }
}
