namespace CustomerManagementApp
{
    partial class CustomPatternForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPattern; 

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
            this.SuspendLayout();

            this.txtPattern = new System.Windows.Forms.TextBox(); 

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPattern); 
            this.Name = "CustomPatternForm";
            this.Text = "CustomPatternForm";
            this.Load += new System.EventHandler(this.CustomPatternForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
