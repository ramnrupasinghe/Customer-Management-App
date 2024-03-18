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
        private Timer responseTimer; // Add a timer for delayed response

        public ChatForm()
        {
            InitializeComponent();
            InitializeChatInput();

            // Initialize the timer
            responseTimer = new Timer();
            responseTimer.Interval = 2000; // Set interval to 2000 milliseconds (2 seconds)
            responseTimer.Tick += ResponseTimer_Tick; // Attach event handler
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
                lstChat.Items.Add($"{message.Sender}: {message.Message}");
            }
            lstChat.ForeColor = Color.White;
        }

        private void lstChat_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Your existing code for drawing chat messages
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

        private void button1_Click(object sender, EventArgs e)
        {
            string messageText = txtUserMessage.Text.Trim();
            if (!string.IsNullOrEmpty(messageText))
            {
                // Add user message to the chat
                ChatMessage userMessage = new ChatMessage("Customer Support", messageText, DateTime.Now);
                chatMessages.Add(userMessage);
                DisplayChatMessages(); // Display the updated chat messages

                // Start the timer after the user sends a message
                responseTimer.Start();
                txtUserMessage.Clear(); // Clear the user input textbox
            }
        }

        private void ResponseTimer_Tick(object sender, EventArgs e)
        {
            // This method will be called after the delay
            responseTimer.Stop(); // Stop the timer

            // Add the delayed response message to the chat
            ChatMessage supportResponse = new ChatMessage("Jhon Doe", "Okay. Thank you so much", DateTime.Now);
            chatMessages.Add(supportResponse);
            DisplayChatMessages(); // Display the updated chat messages
        }
    }
}
