namespace CustomerManagementApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.RadioButton rbSortByName;
        private System.Windows.Forms.RadioButton rbSortByEmail;
        private System.Windows.Forms.RadioButton rbSortByPhone;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnViewReminder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSendEmail;

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
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.rbSortByName = new System.Windows.Forms.RadioButton();
            this.rbSortByEmail = new System.Windows.Forms.RadioButton();
            this.rbSortByPhone = new System.Windows.Forms.RadioButton();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnViewReminder = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.SuspendLayout();

            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(16, 41);
            this.dataGridViewCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCustomers.MultiSelect = false;
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            this.dataGridViewCustomers.RowHeadersWidth = 51;
            this.dataGridViewCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(671, 218);
            this.dataGridViewCustomers.TabIndex = 0;

            this.btnAdd.Location = new System.Drawing.Point(42, 269);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 39);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(42, 321);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 44);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(224, 268);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.txtSearch.Location = new System.Drawing.Point(73, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(13, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 16);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search:";

            this.rbSortByName.AutoSize = true;
            this.rbSortByName.Location = new System.Drawing.Point(285, 12);
            this.rbSortByName.Name = "rbSortByName";
            this.rbSortByName.Size = new System.Drawing.Size(65, 20);
            this.rbSortByName.TabIndex = 6;
            this.rbSortByName.TabStop = true;
            this.rbSortByName.Text = "Name";
            this.rbSortByName.UseVisualStyleBackColor = true;

            this.rbSortByEmail.AutoSize = true;
            this.rbSortByEmail.Location = new System.Drawing.Point(383, 14);
            this.rbSortByEmail.Name = "rbSortByEmail";
            this.rbSortByEmail.Size = new System.Drawing.Size(62, 20);
            this.rbSortByEmail.TabIndex = 7;
            this.rbSortByEmail.TabStop = true;
            this.rbSortByEmail.Text = "Email";
            this.rbSortByEmail.UseVisualStyleBackColor = true;

            this.rbSortByPhone.AutoSize = true;
            this.rbSortByPhone.Location = new System.Drawing.Point(501, 12);
            this.rbSortByPhone.Name = "rbSortByPhone";
            this.rbSortByPhone.Size = new System.Drawing.Size(67, 20);
            this.rbSortByPhone.TabIndex = 8;
            this.rbSortByPhone.TabStop = true;
            this.rbSortByPhone.Text = "Phone";
            this.rbSortByPhone.UseVisualStyleBackColor = true;

            this.btnSort.Location = new System.Drawing.Point(628, 10);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(51, 25);
            this.btnSort.TabIndex = 9;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);

            this.btnExport.Location = new System.Drawing.Point(406, 268);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 40);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.button1.Location = new System.Drawing.Point(224, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "View Detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            this.btnViewReminder.Location = new System.Drawing.Point(558, 269);
            this.btnViewReminder.Name = "btnViewReminder";
            this.btnViewReminder.Size = new System.Drawing.Size(121, 40);
            this.btnViewReminder.TabIndex = 12;
            this.btnViewReminder.Text = "View Reminder";
            this.btnViewReminder.UseVisualStyleBackColor = true;
            this.btnViewReminder.Click += new System.EventHandler(this.btnViewReminder_Click);

            this.button3.Location = new System.Drawing.Point(406, 323);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 40);
            this.button3.TabIndex = 13;
            this.button3.Text = "Add Reminder";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            this.btnSendEmail.Location = new System.Drawing.Point(558, 323);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(121, 40);
            this.btnSendEmail.TabIndex = 14;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 373);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnViewReminder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.rbSortByName);
            this.Controls.Add(this.rbSortByEmail);
            this.Controls.Add(this.rbSortByPhone);
            this.Controls.Add(this.btnSort);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
