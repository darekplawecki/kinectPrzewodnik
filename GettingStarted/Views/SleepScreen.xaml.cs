using Microsoft.Kinect.Toolkit.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class SleepScreen : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public SleepScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        private void OpenMainMenu(object sender, RoutedEventArgs e)
        {
            pageFactory.NavigateTo(pageFactory.GetMainMenu());
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }

        private void SleepScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }


  
    }


}
