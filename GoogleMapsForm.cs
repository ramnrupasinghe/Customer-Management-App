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

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          
            webBrowser.Document.InvokeScript("navigator.geolocation.getCurrentPosition", new object[] { new GeolocationCallback(this) });

     
            webBrowser.Document.InvokeScript("function enableAutocomplete() { var input = document.getElementsByClassName('tactile-searchbox-input')[0]; var autocomplete = new google.maps.places.Autocomplete(input); }");
            webBrowser.Document.InvokeScript("enableAutocomplete");

            webBrowser.Document.InvokeScript("function addCustomMarker(lat, lon, iconUrl) { var marker = new google.maps.Marker({ position: {lat: lat, lng: lon}, map: map, title: 'Selected Location', icon: iconUrl }); }");
        }

        private void SetCustomMarker(string latitude, string longitude, string iconUrl)
        {
            webBrowser.Document.InvokeScript("addCustomMarker", new object[] { latitude, longitude, iconUrl });
        }

        private class GeolocationCallback
        {
            private GoogleMapsForm _parentForm;

            public GeolocationCallback(GoogleMapsForm parentForm)
            {
                _parentForm = parentForm;
            }

            public void Invoke(object position)
            {
                dynamic loc = position;
                double lat = loc.coords.latitude;
                double lon = loc.coords.longitude;

               
                _parentForm.webBrowser.Document.InvokeScript("function addMarker(lat, lon) { var marker = new google.maps.Marker({ position: {lat: lat, lng: lon}, map: map, title: 'Selected Location' }); }");
                _parentForm.webBrowser.Document.InvokeScript("addMarker", new object[] { lat, lon });
            }
        }
    }
}
