using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;

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
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCustomers
            // 
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
            this.dataGridViewCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCustomers_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(46, 280);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 56);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Location = new System.Drawing.Point(223, 280);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 56);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(565, 447);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 56);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(73, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(13, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(53, 16);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search:";
            // 
            // rbSortByName
            // 
            this.rbSortByName.AutoSize = true;
            this.rbSortByName.Location = new System.Drawing.Point(285, 12);
            this.rbSortByName.Name = "rbSortByName";
            this.rbSortByName.Size = new System.Drawing.Size(65, 20);
            this.rbSortByName.TabIndex = 6;
            this.rbSortByName.TabStop = true;
            this.rbSortByName.Text = "Name";
            this.rbSortByName.UseVisualStyleBackColor = true;
            this.rbSortByName.CheckedChanged += new System.EventHandler(this.rbSortByName_CheckedChanged);
            // 
            // rbSortByEmail
            // 
            this.rbSortByEmail.AutoSize = true;
            this.rbSortByEmail.Location = new System.Drawing.Point(383, 14);
            this.rbSortByEmail.Name = "rbSortByEmail";
            this.rbSortByEmail.Size = new System.Drawing.Size(62, 20);
            this.rbSortByEmail.TabIndex = 7;
            this.rbSortByEmail.TabStop = true;
            this.rbSortByEmail.Text = "Email";
            this.rbSortByEmail.UseVisualStyleBackColor = true;
            this.rbSortByEmail.CheckedChanged += new System.EventHandler(this.rbSortByEmail_CheckedChanged);
            // 
            // rbSortByPhone
            // 
            this.rbSortByPhone.AutoSize = true;
            this.rbSortByPhone.Location = new System.Drawing.Point(501, 12);
            this.rbSortByPhone.Name = "rbSortByPhone";
            this.rbSortByPhone.Size = new System.Drawing.Size(67, 20);
            this.rbSortByPhone.TabIndex = 8;
            this.rbSortByPhone.TabStop = true;
            this.rbSortByPhone.Text = "Phone";
            this.rbSortByPhone.UseVisualStyleBackColor = true;
            this.rbSortByPhone.CheckedChanged += new System.EventHandler(this.rbSortByPhone_CheckedChanged);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(628, 10);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(51, 25);
            this.btnSort.TabIndex = 9;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Location = new System.Drawing.Point(395, 280);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 56);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(42, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 56);
            this.button1.TabIndex = 11;
            this.button1.Text = "View Detail";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnViewReminder
            // 
            this.btnViewReminder.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewReminder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewReminder.Location = new System.Drawing.Point(224, 447);
            this.btnViewReminder.Name = "btnViewReminder";
            this.btnViewReminder.Size = new System.Drawing.Size(121, 56);
            this.btnViewReminder.TabIndex = 12;
            this.btnViewReminder.Text = "View Reminder";
            this.btnViewReminder.UseVisualStyleBackColor = false;
            this.btnViewReminder.Click += new System.EventHandler(this.btnViewReminder_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(395, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 56);
            this.button3.TabIndex = 13;
            this.button3.Text = "Add Reminder";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSendEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendEmail.Location = new System.Drawing.Point(565, 356);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(121, 56);
            this.btnSendEmail.TabIndex = 14;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(395, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 56);
            this.button2.TabIndex = 15;
            this.button2.Text = "Export Reminders";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(46, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 67);
            this.button4.TabIndex = 16;
            this.button4.Text = "Add Transaction Reminder";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(229, 356);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 56);
            this.button5.TabIndex = 19;
            this.button5.Text = "Transaction History";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(565, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 56);
            this.button6.TabIndex = 20;
            this.button6.Text = "Add Transaction";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 530);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
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

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void rbSortByName_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbSortByEmail_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rbSortByPhone_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
