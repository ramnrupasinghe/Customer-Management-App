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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rbSortByEmail = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnSaveFilteredLogs = new System.Windows.Forms.Button();
            this.chkFilterByDateRange = new System.Windows.Forms.CheckBox();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.SuspendLayout();
           
            this.dgvActivityLogs.AllowUserToAddRows = false;
            this.dgvActivityLogs.AllowUserToDeleteRows = false;
            this.dgvActivityLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivityLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.ReadOnly = true;
            this.dgvActivityLogs.RowHeadersWidth = 51;
            this.dgvActivityLogs.RowTemplate.Height = 24;
            this.dgvActivityLogs.Size = new System.Drawing.Size(634, 460);
            this.dgvActivityLogs.TabIndex = 0;
            this.dgvActivityLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActivityLogs_CellContentClick);
           
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(55, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
          
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(482, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
           
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(24, 171);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search:";
           
            this.txtSearch.Location = new System.Drawing.Point(97, 168);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(503, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 63);
            this.button3.TabIndex = 8;
            this.button3.Text = "Sort";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
           
            this.button4.BackColor = System.Drawing.Color.Tomato;
            this.button4.Location = new System.Drawing.Point(269, 394);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            
            this.rbSortByEmail.AutoSize = true;
            this.rbSortByEmail.Location = new System.Drawing.Point(187, 223);
            this.rbSortByEmail.Name = "rbSortByEmail";
            this.rbSortByEmail.Size = new System.Drawing.Size(105, 20);
            this.rbSortByEmail.TabIndex = 10;
            this.rbSortByEmail.Text = "ActivityType ";
            this.rbSortByEmail.UseVisualStyleBackColor = true;
            this.rbSortByEmail.CheckedChanged += new System.EventHandler(this.rbSortByEmail_CheckedChanged);
          
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(55, 223);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 20);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.Text = "Name";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
           
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(332, 223);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(130, 20);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.Text = "ActivityDateTime";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
           
            this.btnSaveFilteredLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveFilteredLogs.Location = new System.Drawing.Point(503, 289);
            this.btnSaveFilteredLogs.Name = "btnSaveFilteredLogs";
            this.btnSaveFilteredLogs.Size = new System.Drawing.Size(110, 69);
            this.btnSaveFilteredLogs.TabIndex = 13;
            this.btnSaveFilteredLogs.Text = "Save Filtered";
            this.btnSaveFilteredLogs.UseVisualStyleBackColor = false;
            this.btnSaveFilteredLogs.Click += new System.EventHandler(this.btnSaveFilteredLogs_Click);
             
            this.chkFilterByDateRange.AutoSize = true;
            this.chkFilterByDateRange.Location = new System.Drawing.Point(12, 326);
            this.chkFilterByDateRange.Name = "chkFilterByDateRange";
            this.chkFilterByDateRange.Size = new System.Drawing.Size(152, 20);
            this.chkFilterByDateRange.TabIndex = 14;
            this.chkFilterByDateRange.Text = "Filter by Date Range";
            this.chkFilterByDateRange.UseVisualStyleBackColor = true;
            this.chkFilterByDateRange.CheckedChanged += new System.EventHandler(this.chkFilterByDateRange_CheckedChanged);
             
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(172, 322);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(154, 22);
            this.dateTimePickerStartDate.TabIndex = 15;
            this.dateTimePickerStartDate.Visible = false;
            
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(332, 322);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(148, 22);
            this.dateTimePickerEndDate.TabIndex = 16;
            this.dateTimePickerEndDate.Visible = false;
            
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(169, 289);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(69, 16);
            this.lblStartDate.TabIndex = 17;
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.Visible = false;
           
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(329, 289);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(66, 16);
            this.lblEndDate.TabIndex = 18;
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.Visible = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 460);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.chkFilterByDateRange);
            this.Controls.Add(this.btnSaveFilteredLogs);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rbSortByEmail);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rbSortByEmail;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnSaveFilteredLogs;
        private System.Windows.Forms.CheckBox chkFilterByDateRange;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
    }
}
