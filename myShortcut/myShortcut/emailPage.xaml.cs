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

namespace myShortcut
{
    public partial class emailPage : PhoneApplicationPage
    {
        EmailComposeTask emailComposeTask = new EmailComposeTask();
        public emailPage()
        {
            InitializeComponent();

            
            emailComposeTask.Show();
            
            /*while (true)
            {
                
                if (MessageBox.Show("Would you like to compose new Mail?", "New Mail", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    EmailComposeTask emailComposeTask = new EmailComposeTask();

                    emailComposeTask.Show();
                    continue;
                }
                break;
            }
            
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }*/
        }
    }
}