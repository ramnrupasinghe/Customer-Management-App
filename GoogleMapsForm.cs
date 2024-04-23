using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class GoogleMapsForm : Form
    {
        public string SelectedLocation { get; private set; }

        public GoogleMapsForm()
        {
            InitializeComponent();
        }

        private void GoogleMapsForm_Load(object sender, EventArgs e)
        {
           
            webBrowser.Navigate("https://www.google.com/maps");
        }

        private void btnConfirmLocation_Click(object sender, EventArgs e)
        {
          
            SelectedLocation = $"Latitude: {webBrowser.Document.GetElementById("latitude").InnerText}, Longitude: {webBrowser.Document.GetElementById("longitude").InnerText}";
            DialogResult = DialogResult.OK;
        }
    }
}
