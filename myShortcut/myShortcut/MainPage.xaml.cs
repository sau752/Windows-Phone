using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using Microsoft.Phone.Shell;

namespace myShortcut
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
            connectionSettingsTask.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Cellular;
            connectionSettingsTask.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.AirplaneMode;
            connectionSettingsTask.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Bluetooth;
            connectionSettingsTask.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(mytextBox.Text))
            {
                BingMapsTask bingMapsTask = new BingMapsTask();

                //Omit the Center property to use the user's current location.
                bingMapsTask.Center = new GeoCoordinate();

                bingMapsTask.Show();
            }



            else
            {
                BingMapsTask bingMapsTask = new BingMapsTask();

                bingMapsTask.SearchTerm = mytextBox.Text; ;
                bingMapsTask.ZoomLevel = 2;

                bingMapsTask.Show();
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            

            if (string.IsNullOrEmpty(mytextBox.Text))
            {
                //MessageBox.Show("Please enter application to be searched");

                MarketplaceHubTask marketplaceHubTask = new MarketplaceHubTask();

                marketplaceHubTask.ContentType = MarketplaceContentType.Applications;

                marketplaceHubTask.Show();
            }

            else
            {
                MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

                marketplaceSearchTask.SearchTerms = mytextBox.Text;

                marketplaceSearchTask.Show();
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "My Shortcut Windows Phone App";
            emailComposeTask.To = "sau752@hotmail.com";

            emailComposeTask.Show();
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/aboutUs.xaml", UriKind.Relative));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "WiFi",
                BackgroundImage = new Uri("wifi.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/wifiPage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "Network",
                BackgroundImage = new Uri("network.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/cellularPage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "Airplane",
                BackgroundImage = new Uri("airplane.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/airplanePage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "Bluetooth",
                BackgroundImage = new Uri("bluetooth.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/bluetoothPage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }

        /*private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "New Mail",
                BackgroundImage = new Uri("email.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/emailPage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }*/

        /*private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            StandardTileData newTile = new StandardTileData
            {
                Title = "New SMS",
                BackgroundImage = new Uri("message.png", UriKind.Relative),
            };
            ShellTile.Create(new Uri("/smsPage.xaml?", UriKind.RelativeOrAbsolute), newTile);
        }*/

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "xanium tech.";

            marketplaceSearchTask.Show();
        }
    }
}