namespace CustomerManagementApp
{
    partial class ChatForm
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
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.lstChat.BackColor = System.Drawing.Color.LavenderBlush;
            this.lstChat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 60;
            this.lstChat.Location = new System.Drawing.Point(16, 15);
            this.lstChat.Margin = new System.Windows.Forms.Padding(4);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(909, 484);
            this.lstChat.TabIndex = 0;
            this.lstChat.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstChat_DrawItem);
            this.lstChat.SelectedIndexChanged += new System.EventHandler(this.lstChat_SelectedIndexChanged);
            
            this.txtMessage.BackColor = System.Drawing.Color.Thistle;
            this.txtMessage.Location = new System.Drawing.Point(16, 489);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(591, 45);
            this.txtMessage.TabIndex = 1;
            
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(829, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
           
            this.btnRecord.BackColor = System.Drawing.Color.SkyBlue;
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.Location = new System.Drawing.Point(625, 489);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(96, 45);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
           
            this.btnAttach.BackColor = System.Drawing.Color.LightGreen;
            this.btnAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttach.Location = new System.Drawing.Point(727, 489);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(96, 45);
            this.btnAttach.TabIndex = 4;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 566);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lstChat);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatForm";
            this.Text = "Chat Form";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnAttach;
    }
}
