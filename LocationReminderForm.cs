using System;
using System.IO;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class LocationReminderForm : Form
    {
        public string SelectedLocation { get; private set; }

        private const string LocationFileName = "last_location.txt";

        public LocationReminderForm()
        {
            InitializeComponent();
        }

        private void LocationReminderForm_Load(object sender, EventArgs e)
        {
            LoadLastLocation();
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            using (var mapForm = new GoogleMapsForm())
            {
                if (mapForm.ShowDialog() == DialogResult.OK)
                {
                    SelectedLocation = mapForm.SelectedLocation;
                    SaveLastLocation();
                    MessageBox.Show($"Location set to: {SelectedLocation}", "Location Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            string latitude = Microsoft.VisualBasic.Interaction.InputBox("Enter latitude:", "Latitude", "");
            string longitude = Microsoft.VisualBasic.Interaction.InputBox("Enter longitude:", "Longitude", "");

            if (!string.IsNullOrWhiteSpace(latitude) && !string.IsNullOrWhiteSpace(longitude))
            {
                SelectedLocation = $"Latitude: {latitude}, Longitude: {longitude}";
                SaveLastLocation();
                MessageBox.Show($"Location set to: {SelectedLocation}", "Location Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter both latitude and longitude.", "Location Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveLastLocation()
        {
            try
            {
                File.WriteAllText(LocationFileName, SelectedLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving last location: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLastLocation()
        {
            try
            {
                if (File.Exists(LocationFileName))
                {
                    SelectedLocation = File.ReadAllText(LocationFileName);
                    MessageBox.Show($"Last selected location loaded: {SelectedLocation}", "Location Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading last location: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
