using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.Views;
using Przewodnik;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Utilities;

namespace Przewodnik.Views
{
    partial class MapPage : IKinectPage
    {
        private KinectPageFactory _pageFactory;


        public MapPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            _pageFactory = pageFactory;

            //addPin(51.105726, 17.030613, "Opera Wrocławska");
            //addPin(51.109588, 17.032255, "Ratusz");
            //addPin(51.113313, 17.004950, "Muzeum współczesne Wrocław");
            //addPin(51.110178, 17.044595, "Panorama Racławicka");
        }

        public Grid GetView()
        {
            return MapPageGrid;
        }

        private void addPin(double latitude, double longitude, String desc)
        {
            Pushpin pin = new Pushpin();
            pin.Location = new Location(latitude, longitude);
            pin.ToolTip = desc;
            MasterBingMap.Children.Add(pin);
        }

        public void OnNavigateTo()
        {
        }

    }
    
}
