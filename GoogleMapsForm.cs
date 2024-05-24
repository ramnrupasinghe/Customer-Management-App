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
            // Retrieving latitude and longitude from hidden elements
            HtmlElement latitudeElement = webBrowser.Document.GetElementById("latitude");
            HtmlElement longitudeElement = webBrowser.Document.GetElementById("longitude");

            if (latitudeElement != null && longitudeElement != null)
            {
                string latitude = latitudeElement.InnerText;
                string longitude = longitudeElement.InnerText;
                SelectedLocation = $"Latitude: {latitude}, Longitude: {longitude}";
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a location first.");
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.Document.InvokeScript("navigator.geolocation.getCurrentPosition", new object[] { new GeolocationCallback(this) });

            webBrowser.Document.InvokeScript(@"
                function enableAutocomplete() { 
                    var input = document.getElementsByClassName('tactile-searchbox-input')[0]; 
                    var autocomplete = new google.maps.places.Autocomplete(input); 
                    autocomplete.addListener('place_changed', function() { 
                        var place = autocomplete.getPlace(); 
                        if (!place.geometry) { 
                            return; 
                        } 
                        map.setCenter(place.geometry.location); 
                        addMarker(place.geometry.location.lat(), place.geometry.location.lng()); 
                    }); 
                }
                function addMarker(lat, lon) { 
                    var marker = new google.maps.Marker({ 
                        position: {lat: lat, lng: lon}, 
                        map: map, 
                        title: 'Selected Location' 
                    }); 
                    document.getElementById('latitude').innerText = lat;
                    document.getElementById('longitude').innerText = lon;
                }
                function addClickListener() { 
                    map.addListener('click', function(e) { 
                        addMarker(e.latLng.lat(), e.latLng.lng()); 
                    }); 
                }
                enableAutocomplete();
                addClickListener();
            ");

            // Adding the hidden elements to store selected latitude and longitude
            webBrowser.Document.InvokeScript(@"
                var latElement = document.createElement('div');
                latElement.id = 'latitude';
                latElement.style.display = 'none';
                document.body.appendChild(latElement);

                var lonElement = document.createElement('div');
                lonElement.id = 'longitude';
                lonElement.style.display = 'none';
                document.body.appendChild(lonElement);
            ");
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

                _parentForm.webBrowser.Document.InvokeScript("addMarker", new object[] { lat, lon });
            }
        }
    }
}
