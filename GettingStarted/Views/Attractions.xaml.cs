using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect;
using Przewodnik.Content.Traslations;
using Przewodnik.Views;
using Przewodnik;
using Microsoft.Kinect.Toolkit.Controls;

namespace GettingStarted
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
            string parametr = ((KinectTileButton)sender).Name;
            IKinectPage attractionArticle = pageFactory.GetAttractionArticleGrid(parametr);
            pageFactory.NavigateTo(attractionArticle);
        }

        public void OnNavigateTo()
        {
            preprareTranslation();
        }



        private void preprareTranslation()
        {
            FontannaBlock.Text = AppResources.GetText("A_FONTANNA_TITLE");
            HalaBlock.Text = AppResources.GetText("A_HALA_STULECIA_TITLE");
            OgrodBBlock.Text = AppResources.GetText("A_OGROD_BOTANICZNY_TITLE");
            OgrodJBlock.Text = AppResources.GetText("A_OGROD_JAPONSKI_TITLE");
            PalacBlock.Text = AppResources.GetText("A_PALAC_KROLEWSKI_TITLE");
            RynekBlock.Text = AppResources.GetText("A_RYNEK_TITLE");
            WyspaBlock.Text = AppResources.GetText("A_WYSPA_SLODOWA_TITLE");
        }

    }


}
