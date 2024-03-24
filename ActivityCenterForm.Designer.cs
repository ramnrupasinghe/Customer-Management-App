namespace CustomerManagementApp
{
    partial class ActivityCenterForm
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
            this.dgvActivityLogs = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActivityLogs
            // 
            this.dgvActivityLogs.AllowUserToAddRows = false;
            this.dgvActivityLogs.AllowUserToDeleteRows = false;
            this.dgvActivityLogs.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivityLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.ReadOnly = true;
            this.dgvActivityLogs.RowHeadersWidth = 51;
            this.dgvActivityLogs.RowTemplate.Height = 24;
            this.dgvActivityLogs.Size = new System.Drawing.Size(634, 256);
            this.dgvActivityLogs.TabIndex = 0;
            this.dgvActivityLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivityLogs_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(24, 171);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(97, 168);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ActivityCenterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 256);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvActivityLogs);
            this.Name = "ActivityCenterForm";
            this.Text = "Activity Center";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActivityLogs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
