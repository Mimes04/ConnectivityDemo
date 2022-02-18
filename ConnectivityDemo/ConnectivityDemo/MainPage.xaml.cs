using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;

namespace ConnectivityDemo
{
    /// <summary>
    /// A code demo for the Connectivity class.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Similar to Status_Clicked event, the connectivity will check the profile that device is using (type of connection). 
        /// Display alert message if one of these matched.
        /// </summary>
        public void TypeConnection()
        {
            var profile = Connectivity.ConnectionProfiles;
            
            if (profile.Contains(ConnectionProfile.WiFi))
            {
                DisplayAlert("Type of Connection", "WIFI", "Ok");
                connectMsg.FadeTo(0);
            }
            else if (profile.Contains(ConnectionProfile.Bluetooth))
            {
                DisplayAlert("Type of Connection", "Bluetooth", "Ok");
            }
            else if (profile.Contains(ConnectionProfile.Cellular))
            {
                connectMsg.FadeTo(0);
                DisplayAlert("Type of Connection", "Cellular/Data Network", "Ok");
            }
            else if (profile.Contains(ConnectionProfile.Ethernet))
            {
                DisplayAlert("Type of Connection", "Ethernet", "Ok");
            }
            else if (profile.Contains(ConnectionProfile.Unknown))
            {
                DisplayAlert("Type of Connection", "Unknown", "Ok");
            }
        }
        /// <summary>
        /// Connectivity will check the status of connection between user's device and the internet. Display alert messages
        /// if one of these occur. Also, the "disconnected" message will appear after alert message. It is an example that Connectivity Changed event was used for.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                connectMsg.FadeTo(1);
                DisplayAlert("Status", "No Internet Connection!", "Ok");
            }
            else if (Connectivity.NetworkAccess == NetworkAccess.Local)
            {
                DisplayAlert("Status", "Connecting to Local Internet Connection!", "Ok");
            }
            else if (Connectivity.NetworkAccess == NetworkAccess.ConstrainedInternet)
            {
                DisplayAlert("Status", "Connecting to restricted Internet!", "Ok");
            }
            else if (Connectivity.NetworkAccess == NetworkAccess.Unknown)
            {
                DisplayAlert("Status", "Unknown connection...", "Ok");
            }
            else if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                DisplayAlert("Status", "No connection at all", "Ok");
                connectMsg.FadeTo(1);
            }
            TypeConnection();
        }
    }
}
