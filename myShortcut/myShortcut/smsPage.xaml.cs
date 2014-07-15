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
    public partial class smsPage : PhoneApplicationPage
    {
        public smsPage()
        {
            InitializeComponent();

            while (true)
            {
                
                if (MessageBox.Show("Would you like to compose new Message?", "New Message", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    SmsComposeTask smsComposeTask = new SmsComposeTask();

                    smsComposeTask.Show();
                    continue;
                }
                break;
            }
            
                
            
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();

            }
            
            
        }
        
    }
}