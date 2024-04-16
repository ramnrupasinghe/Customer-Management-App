using System;
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
                lstChat.Items.Add($"{message.Sender}: {message.Message} ");
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

            public ChatMessage(string sender, string message, DateTime timestamp)
            {
                Sender = sender;
                Message = message;
                Timestamp = timestamp;
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
    }
}
