using System.Windows;
using System.Windows.Controls;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Views
{

    partial class MainMenu : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public MainMenu(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            
        }

        public Grid GetView()
        {
            return MainMenuGrid;
        }

        public void OnNavigateTo()
        {
            //KinectTileButton bb = new KinectTileButton();
            //bb.
            TwitterPageButton.Content = "Twitter";// +  "\n"+TwitterManager.Instance.getLastDate();
            TwitterLabel.Text = TwitterManager.Instance.GetLastDate();
            //TwitterPageButton.Label = TwitterManager.Instance.getLastDate();
            //TwitterPageButton.LabelTemplate.
        }

        private void touristAttractions_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage attractions = pageFactory.GetAttractionsGrid();
            pageFactory.NavigateTo(attractions);
        }

        private void twitterPageButton_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage twitterPage = pageFactory.GetTwitterPageGrid();
            pageFactory.NavigateTo(twitterPage);
        }

    }


}
