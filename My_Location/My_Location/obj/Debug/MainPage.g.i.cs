﻿#pragma checksum "E:\STUDY MATERIAL\MOBILE PLATFORM\WINDOWS PHONE\My_Location\My_Location\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DF8C41893879959D83AE3794E3E11665"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace My_Location {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock myTextBlockButton;
        
        internal System.Windows.Controls.Button myDataButton;
        
        internal System.Windows.Controls.Button myWiFiButton;
        
        internal System.Windows.Controls.Button myRefreshButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/My_Location;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.myTextBlockButton = ((System.Windows.Controls.TextBlock)(this.FindName("myTextBlockButton")));
            this.myDataButton = ((System.Windows.Controls.Button)(this.FindName("myDataButton")));
            this.myWiFiButton = ((System.Windows.Controls.Button)(this.FindName("myWiFiButton")));
            this.myRefreshButton = ((System.Windows.Controls.Button)(this.FindName("myRefreshButton")));
        }
    }
}

