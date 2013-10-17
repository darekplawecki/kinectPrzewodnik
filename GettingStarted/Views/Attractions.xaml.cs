using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class Attractions : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public Attractions(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        public Grid GetView()
        {
            return AttractionsGrid;
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            IKinectPage attractionArticle = pageFactory.GetAttractionArticleGrid();
            pageFactory.NavigateTo(attractionArticle);
        }



    }


}
