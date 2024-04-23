namespace CustomerManagementApp
{
    partial class GoogleMapsForm
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btnConfirmLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
             
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(800, 400);
            this.webBrowser.TabIndex = 0;
           
            this.btnConfirmLocation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfirmLocation.Location = new System.Drawing.Point(0, 400);
            this.btnConfirmLocation.Name = "btnConfirmLocation";
            this.btnConfirmLocation.Size = new System.Drawing.Size(800, 50);
            this.btnConfirmLocation.TabIndex = 1;
            this.btnConfirmLocation.Text = "Confirm Location";
            this.btnConfirmLocation.UseVisualStyleBackColor = true;
            this.btnConfirmLocation.Click += new System.EventHandler(this.btnConfirmLocation_Click);
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmLocation);
            this.Controls.Add(this.webBrowser);
            this.Name = "GoogleMapsForm";
            this.Text = "Google Maps";
            this.Load += new System.EventHandler(this.GoogleMapsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button btnConfirmLocation;
    }
}
