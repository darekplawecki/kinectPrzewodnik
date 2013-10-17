using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class AttractionArticle : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public AttractionArticle(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        public Grid GetView()
        {
            return AttractionArticleGrid;
        }

        
    }


}
