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

        private void btnPreviewMap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SelectedLocation))
            {
                using (var mapPreviewForm = new MapPreviewForm(SelectedLocation))
                {
                    mapPreviewForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No location selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnSaveAdditionalInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SelectedLocation))
            {
                string additionalInfo = Microsoft.VisualBasic.Interaction.InputBox("Enter additional information about the location:", "Additional Information", "");

                if (!string.IsNullOrWhiteSpace(additionalInfo))
                {
                  
                    SelectedLocation += Environment.NewLine + "Additional Info: " + additionalInfo;
                    SaveLastLocation();
                    MessageBox.Show("Additional information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No additional information entered.", "Information Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No location selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
