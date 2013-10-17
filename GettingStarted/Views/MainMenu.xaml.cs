using System.Windows;
using System.Windows.Controls;

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

        private void touristAttractions_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage attractions = pageFactory.GetAttractionsGrid();
            pageFactory.NavigateTo(attractions);
        }
    }


}
