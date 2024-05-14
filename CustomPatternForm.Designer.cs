namespace CustomerManagementApp
{
    partial class CustomPatternForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnSave;

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
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();

            this.SuspendLayout();

     
            this.txtPattern.Location = new System.Drawing.Point(50, 50);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(300, 22);
            this.txtPattern.TabIndex = 0;

           
            this.btnSave.Location = new System.Drawing.Point(150, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

     
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPattern);
            this.Name = "CustomPatternForm";
            this.Text = "Custom Pattern Form";
            this.Load += new System.EventHandler(this.CustomPatternForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
