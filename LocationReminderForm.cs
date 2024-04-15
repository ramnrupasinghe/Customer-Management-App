using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class LocationReminderForm : Form
    {
        public string SelectedLocation { get; private set; }

        public LocationReminderForm()
        {
            InitializeComponent();
        }

        private void LocationReminderForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSetLocation_Click(object sender, EventArgs e)
        {
            
            string latitude = Microsoft.VisualBasic.Interaction.InputBox("Enter latitude:", "Latitude", "");
            string longitude = Microsoft.VisualBasic.Interaction.InputBox("Enter longitude:", "Longitude", "");

            if (!string.IsNullOrWhiteSpace(latitude) && !string.IsNullOrWhiteSpace(longitude))
            {
                SelectedLocation = $"Latitude: {latitude}, Longitude: {longitude}";
                MessageBox.Show($"Location set to: {SelectedLocation}", "Location Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter both latitude and longitude.", "Location Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
