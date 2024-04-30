using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class MapPreviewForm : Form
    {
        private string _selectedLocation;

        public MapPreviewForm(string selectedLocation)
        {
            InitializeComponent();
            _selectedLocation = selectedLocation;
        }

        private void MapPreviewForm_Load(object sender, EventArgs e)
        {
            webBrowserMap.Navigate($"https://www.google.com/maps?q={_selectedLocation}");
        }

        private void webBrowserMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
