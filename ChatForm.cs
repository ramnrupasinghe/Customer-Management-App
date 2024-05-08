﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class ChatForm : Form
    {
        private List<ChatMessage> chatMessages = new List<ChatMessage>();
        private TextBox txtUserMessage;
        private bool isRecording = false;
        private string audioFilePath;
        private string attachedFilePath;

        public ChatForm()
        {
            InitializeComponent();
            InitializeChatInput();
        }

        private void InitializeChatInput()
        {
            txtUserMessage = new TextBox();
            txtUserMessage.Multiline = true;
            txtUserMessage.Location = new Point(12, 320);
            txtUserMessage.Size = new Size(600, 30);
            txtUserMessage.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            Controls.Add(txtUserMessage);
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            LoadChatHistory();
        }

        private void LoadChatHistory()
        {
            chatMessages.Add(new ChatMessage("Customer Support", "Hello! How can I assist you today?", DateTime.Now));
            chatMessages.Add(new ChatMessage("John Doe", "I have a query regarding my recent purchase.", DateTime.Now.AddMinutes(2)));
            chatMessages.Add(new ChatMessage("Customer Support", "Sure, please let me know your query.", DateTime.Now.AddMinutes(3)));
            chatMessages.Add(new ChatMessage("John Doe", "I'd like to inquire about the delivery status of my recent order.", DateTime.Now.AddMinutes(4)));

            DisplayChatMessages();
        }

        private void DisplayChatMessages()
        {
            lstChat.Items.Clear();
            foreach (var message in chatMessages)
            {
                string reactions = string.Join(", ", message.Reactions);
                lstChat.Items.Add($"{message.Sender}: {message.Message} {(reactions != "" ? $"Reactions: {reactions}" : "")}");
            }
            lstChat.ForeColor = Color.White;
        }

        private void lstChat_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index >= 0)
            {
                string message = lstChat.Items[e.Index].ToString();
                Brush brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Brushes.White : Brushes.Black;

                string[] parts = message.Split(':');
                string senderName = parts[0];
                string messageText = parts.Length > 1 ? parts[1] : "";

                Color senderColor = senderName.Equals("You") ? Color.LightYellow : Color.Purple;

                using (Font senderFont = new Font("Arial", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(senderName, senderFont, new SolidBrush(senderColor), e.Bounds.Left, e.Bounds.Top);
                }

                using (Font messageFont = new Font("Arial", 10))
                {
                    e.Graphics.DrawString(messageText, messageFont, brush, e.Bounds.Left, e.Bounds.Top + 20);
                }
            }
            e.DrawFocusRectangle();
        }

        public class ChatMessage
        {
            public string Sender { get; }
            public string Message { get; }
            public DateTime Timestamp { get; }
            public List<string> Reactions { get; set; }

            public ChatMessage(string sender, string message, DateTime timestamp)
            {
                Sender = sender;
                Message = message;
                Timestamp = timestamp;
                Reactions = new List<string>();
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                StopRecording();
                isRecording = false;
                btnRecord.Text = "Record";
            }
            else
            {
                StartRecording();
                isRecording = true;
                btnRecord.Text = "Stop";
            }
        }

        private void StartRecording()
        {
            MessageBox.Show("Recording started...");
        }

        private void StopRecording()
        {
            MessageBox.Show("Recording stopped.");
        }

        private void picAttach_Click(object sender, EventArgs e)
        {

        }

        private void picRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                attachedFilePath = openFileDialog.FileName;
                MessageBox.Show("File attached: " + attachedFilePath);
            }
        }

        private void lstChat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string messageText = txtUserMessage.Text.Trim();
            if (!string.IsNullOrEmpty(messageText) || !string.IsNullOrEmpty(audioFilePath) || !string.IsNullOrEmpty(attachedFilePath))
            {
                if (!string.IsNullOrEmpty(messageText))
                {
                    ChatMessage userMessage = new ChatMessage("Customer Support", messageText, DateTime.Now);
                    chatMessages.Add(userMessage);
                }

                if (!string.IsNullOrEmpty(audioFilePath))
                {
                    ChatMessage audioMessage = new ChatMessage("Customer Support", "Audio Message", DateTime.Now);
                    chatMessages.Add(audioMessage);
                }

                if (!string.IsNullOrEmpty(attachedFilePath))
                {
                    ChatMessage fileMessage = new ChatMessage("Customer Support", "File Attachment", DateTime.Now);
                    chatMessages.Add(fileMessage);
                }

                DisplayChatMessages();
                txtUserMessage.Clear();
                audioFilePath = null;
                attachedFilePath = null;
            }
            else
            {
                MessageBox.Show("Please enter a message or attach a file.");
            }
        }


        private void btnAddEmoji_Click(object sender, EventArgs e)
        {

            txtUserMessage.Text += " 😊";
            txtUserMessage.Focus();
            txtUserMessage.SelectionStart = txtUserMessage.Text.Length;
        }


        private void lstChat_DoubleClick(object sender, EventArgs e)
        {

            if (lstChat.SelectedItem != null)
            {
                string selectedMessage = lstChat.SelectedItem.ToString();
                string[] parts = selectedMessage.Split(':');
                string senderName = parts[0].Trim();
                string messageText = parts.Length > 1 ? parts[1].Trim() : "";


                if (senderName.Equals("You", StringComparison.OrdinalIgnoreCase))
                {

                    txtUserMessage.Text = messageText;

                    chatMessages.RemoveAt(lstChat.SelectedIndex);

                    DisplayChatMessages();
                }
                else
                {
                    MessageBox.Show("You can only edit your messages.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string searchTerm = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                List<ChatMessage> filteredMessages = chatMessages
                    .Where(message => message.Message.Contains(searchTerm))
                    .ToList();

                if (filteredMessages.Any())
                {
                    lstChat.Items.Clear();
                    foreach (var message in filteredMessages)
                    {
                        lstChat.Items.Add($"{message.Sender}: {message.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("No messages found matching the search term.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a search term.");
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddReaction(string selectedMessage, string reaction)
        {
            foreach (var message in chatMessages)
            {
                if (selectedMessage.Contains(message.Message))
                {
                    message.Reactions.Add(reaction);
                    break;
                }
            }
        }

        private void lstChat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstChat.SelectedItem != null)
            {
                string selectedMessage = lstChat.SelectedItem.ToString();
                string[] parts = selectedMessage.Split(':');
                string senderName = parts[0].Trim();

                if (senderName.Equals("You", StringComparison.OrdinalIgnoreCase))
                {
                    txtUserMessage.Text = parts.Length > 1 ? parts[1].Trim() : "";
                    chatMessages.RemoveAt(lstChat.SelectedIndex);
                    DisplayChatMessages();
                }
                else
                {
                    ForwardMessage(selectedMessage);
                }
            }
        }

        private void ForwardMessage(string selectedMessage)
        {
            string[] parts = selectedMessage.Split(':');
            string messageText = parts.Length > 1 ? parts[1].Trim() : "";


            List<string> contactsList = new List<string> { "Recipient1", "Recipient2", "Recipient3" }; 

            SelectRecipientForm selectRecipientForm = new SelectRecipientForm(contactsList);
            DialogResult result = selectRecipientForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedRecipient = selectRecipientForm.SelectedRecipient;
                if (!string.IsNullOrEmpty(selectedRecipient))
                {

                    ChatMessage forwardedMessage = new ChatMessage(selectedRecipient, messageText, DateTime.Now);
                    chatMessages.Add(forwardedMessage);


                    DisplayChatMessages();
                }
            }
        }
    }
}
