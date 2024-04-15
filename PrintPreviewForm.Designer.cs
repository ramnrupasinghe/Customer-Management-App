namespace CustomerManagementApp
{
    partial class PrintPreviewForm
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActivityLogs
            // 
            this.dgvActivityLogs.AllowUserToAddRows = false;
            this.dgvActivityLogs.AllowUserToDeleteRows = false;
            this.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLogs.Location = new System.Drawing.Point(12, 12);
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.ReadOnly = true;
            this.dgvActivityLogs.RowHeadersWidth = 51;
            this.dgvActivityLogs.RowTemplate.Height = 24;
            this.dgvActivityLogs.Size = new System.Drawing.Size(776, 374);
            this.dgvActivityLogs.TabIndex = 0;
            this.dgvActivityLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivityLogs_CellContentClick);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPrint.Location = new System.Drawing.Point(542, 392);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(103, 46);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancel.Location = new System.Drawing.Point(694, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 46);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PrintPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvActivityLogs);
            this.Name = "PrintPreviewForm";
            this.Text = "PrintPreviewForm";
            this.Load += new System.EventHandler(this.PrintPreviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActivityLogs;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
    }
}
