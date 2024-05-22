namespace CustomerManagementApp
{
    partial class SuggestionForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxSuggestions = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAutoSuggest = new System.Windows.Forms.TextBox();
            this.lblRuleDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();

      
            this.listBoxSuggestions.FormattingEnabled = true;
            this.listBoxSuggestions.ItemHeight = 16;
            this.listBoxSuggestions.Location = new System.Drawing.Point(12, 39);
            this.listBoxSuggestions.Name = "listBoxSuggestions";
            this.listBoxSuggestions.Size = new System.Drawing.Size(776, 244);
            this.listBoxSuggestions.TabIndex = 0;
            this.listBoxSuggestions.SelectedIndexChanged += new System.EventHandler(this.listBoxSuggestions_SelectedIndexChanged);

           
            this.btnOk.Location = new System.Drawing.Point(632, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 38);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            this.btnCancel.Location = new System.Drawing.Point(713, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.txtAutoSuggest.Location = new System.Drawing.Point(12, 12);
            this.txtAutoSuggest.Name = "txtAutoSuggest";
            this.txtAutoSuggest.Size = new System.Drawing.Size(776, 22);
            this.txtAutoSuggest.TabIndex = 3;
            this.txtAutoSuggest.TextChanged += new System.EventHandler(this.txtAutoSuggest_TextChanged);

            
            this.lblRuleDetails.AutoSize = true;
            this.lblRuleDetails.Location = new System.Drawing.Point(12, 307);
            this.lblRuleDetails.Name = "lblRuleDetails";
            this.lblRuleDetails.Size = new System.Drawing.Size(46, 17);
            this.lblRuleDetails.TabIndex = 4;
            this.lblRuleDetails.Text = "Details";

          
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRuleDetails);
            this.Controls.Add(this.txtAutoSuggest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listBoxSuggestions);
            this.Name = "SuggestionForm";
            this.Text = "SuggestionForm";
            this.Load += new System.EventHandler(this.SuggestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSuggestions;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAutoSuggest;
        private System.Windows.Forms.Label lblRuleDetails;
    }
}
