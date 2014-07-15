using System;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using System.Threading;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.UserData;
using System.Device.Location;
using Microsoft.Phone;
using Microsoft.Phone.Net.NetworkInformation;
using System.Collections;

namespace My_Location
{
    public partial class MainPage : PhoneApplicationPage
    {
        private static GeoCoordinateWatcher coordinateWatcher = null;
        public static string Address;
        PhoneNumberChooserTask phoneNumberChooserTask;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Thread.Sleep(200);
            myDataButton.Visibility = Visibility.Collapsed;
            myWiFiButton.Visibility = Visibility.Collapsed;
            myRefreshButton.Visibility = Visibility.Collapsed;

            phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);

            MessageBoxResult result = MessageBox.Show("This application requires your location access, press OK to continue", "User Location", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                if (DeviceNetworkInformation.IsCellularDataEnabled || DeviceNetworkInformation.IsWiFiEnabled)
                {
                    myTextBlockButton.Text = "Please Wait...";
                    coordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                    coordinateWatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(coordinateWatcher_StatusChanged);
                    coordinateWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(coordinateWatcher_PositionChanged);
                    coordinateWatcher.Start();
                }
                else
                {
                    ApplicationBar.IsVisible = false;
                    myTextBlockButton.Text = "Please enable Cellular Data or WiFi to access your Location.";
                    myDataButton.Visibility = Visibility.Visible;
                    myWiFiButton.Visibility = Visibility.Visible;
                    myRefreshButton.Visibility = Visibility.Visible;
                }
            }
            else
            {
                myTextBlockButton.Text = "Location access not granted please exit application.";
                ApplicationBar.IsVisible = false;
            }
        }

        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //MessageBox.Show("The phone number for " + e.DisplayName + " is " + e.PhoneNumber);
                
                //Code to start a new call using the retrieved phone number.
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.DisplayName = e.DisplayName;
                phoneCallTask.PhoneNumber = e.PhoneNumber;
                phoneCallTask.Show();
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            e.Cancel = false;
        }

        private void coordinateWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            GeoPositionStatus status = e.Status;
            if (status == GeoPositionStatus.Disabled)
            {
                coordinateWatcher.Stop();           // Preserve the battery life
                coordinateWatcher = null;
            }
            else if (status == GeoPositionStatus.Ready)
            {
                /* Do Nothing */
            }
            else if (status == GeoPositionStatus.NoData)
            {
                coordinateWatcher.Stop();           // Preserve the battery life
                coordinateWatcher = null;
            }
        }

        private void coordinateWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            GeoCoordinate coordinates = e.Position.Location;
            string geoCode = coordinates.Latitude + "," + coordinates.Longitude;

            getResponse(geoCode);

            coordinateWatcher.Stop();       // Save the battery
            coordinateWatcher = null;
        }

        private void getResponse(string gpsCodes)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_DownloadStringCompleted;
            string Url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + gpsCodes + "&sensor=true&key=AIzaSyB5GzHXxr1_uwsohSMRC-JfLfQoKHzGeDc";
            client.DownloadStringAsync(new Uri(Url, UriKind.RelativeOrAbsolute));
            Console.Write("", "");
        }

        public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var getResult = e.Result;
            JObject parseJson = JObject.Parse(getResult);
            var getJsonres = parseJson["results"][0];
            //var getJson = getJsonres["address_components"][1];
            var getAddress = getJsonres["formatted_address"];
            string Address = getAddress.ToString();
            myTextBlockButton.Text = Address + " (approx. 500m)";
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            phoneNumberChooserTask.Show();
        }
             
        
        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.To = "";
            smsComposeTask.Body = "My current location is :-\n\n"+ myTextBlockButton.Text;

            smsComposeTask.Show();
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "My Location";
            emailComposeTask.Body = "My current location is :-\n\n" + myTextBlockButton.Text;
            emailComposeTask.To = "";

            emailComposeTask.Show();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "My Location Application Windows Phone";
            emailComposeTask.Body = "";
            emailComposeTask.To = "sau752@hotmail.com";

            emailComposeTask.Show();
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/aboutUs.xaml", UriKind.Relative));
        }

        private void myDataButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Cellular;
            connectionSettingsTask.Show();

        }

        private void myWiFiButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
            connectionSettingsTask.Show();

        }

        private void myRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(string.Format("/MainPage.xaml?Refresh=true&random={0}", Guid.NewGuid()), UriKind.Relative));
        }

        
    }
}