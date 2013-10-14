using System.Windows;
using System.Windows.Controls;
using Microsoft.Kinect.Toolkit.Controls;

namespace Przewodnik.Views
{
    class SecondPage : IKinectPage
    {

        private Grid grid;
        private KinectPageFactory pageFactory;

        public SecondPage(KinectPageFactory pageFactory)
        {
            grid = new Grid();
            this.pageFactory = pageFactory;
            KinectTileButton button = new KinectTileButton();
            button.Label = "Hola!";
            button.Click += OpenThird;
            button.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            button.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            grid.Children.Add(button);
        }

        private void OpenThird(object sender, RoutedEventArgs e)
        {
            IKinectPage third = pageFactory.GetThirdGrid();
            pageFactory.NavigateTo(third);
        }

        public Grid GetView()
        {
            return grid;
        }
    }
}
