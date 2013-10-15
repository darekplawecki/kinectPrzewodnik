using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Kinect.Toolkit.Controls;

namespace GettingStarted
{
    class ThirdPage : IKinectPage
    {

        private Grid grid;
        private KinectPageFactory pageFactory;

        public ThirdPage(KinectPageFactory pageFactory)
        {
            this.pageFactory = pageFactory;
            grid = new Grid();
            KinectTileButton button = new KinectTileButton();
            button.Label = "Hallo!";
            button.Click += OpenThird;
            button.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            button.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            grid.Children.Add(button);
        }

        private void OpenThird(object sender, RoutedEventArgs e)
        {
            IKinectPage first = pageFactory.GetFirstPage();
            pageFactory.NavigateTo(first);
        }

        public Grid GetView()
        {
            return grid;
        }
    }
}
