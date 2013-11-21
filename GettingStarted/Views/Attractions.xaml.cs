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
using System.Text.RegularExpressions;

namespace GettingStarted
{

    partial class Attractions : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public Attractions(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            InitializeKinectButtonHover();
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
            firstTextBlock.Text = AppResources.GetText("M_atrakcje_turystyczne");
            FontannaBlock.Text = AppResources.GetText("A_FONTANNA_TITLE");
            HalaBlock.Text = AppResources.GetText("A_HALA_STULECIA_TITLE");
            OgrodBBlock.Text = AppResources.GetText("A_OGROD_BOTANICZNY_TITLE");
            OgrodJBlock.Text = AppResources.GetText("A_OGROD_JAPONSKI_TITLE");
            PalacBlock.Text = AppResources.GetText("A_PALAC_KROLEWSKI_TITLE");
            RynekBlock.Text = AppResources.GetText("A_RYNEK_TITLE");
            WyspaBlock.Text = AppResources.GetText("A_WYSPA_SLODOWA_TITLE");
        }

        private void OnHandPointerEnter(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            KinectTileButton button = sender as KinectTileButton;
            Image image = button.FindName(button.Name + "Image") as Image;

            string pattern = "/Content/Attractions/Photos/(.*?)1_hover.jpg";
            Match m = Regex.Match(image.Source.ToString(), @pattern);
            string attraction_name = "";
            if (m.Success) attraction_name = m.Groups[1].ToString();
            
            image.Source = new BitmapImage(new Uri("../Content/Attractions/Photos/" + attraction_name + "1.jpg", UriKind.Relative));
        }

        private void OnHandPointerLeave(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            KinectTileButton button = sender as KinectTileButton;
            Image image = button.FindName(button.Name + "Image") as Image;

            string pattern = "/Content/Attractions/Photos/(.*?)1.jpg";
            Match m = Regex.Match(image.Source.ToString(), @pattern);
            string attraction_name = "";
            if (m.Success) attraction_name = m.Groups[1].ToString();

            image.Source = new BitmapImage(new Uri("../Content/Attractions/Photos/" + attraction_name + "1_hover.jpg", UriKind.Relative));
        }

        private void InitializeKinectButtonHover()
        {
            KinectRegion.AddHandPointerEnterHandler(Rynek, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(Rynek, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(OstrówTumski, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(OstrówTumski, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(HalaStulecia, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(HalaStulecia, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(PałacKrólewski, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(PałacKrólewski, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(PanoramaRacławicka, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(PanoramaRacławicka, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(OgródJapoński, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(OgródJapoński, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(FontannaMultimedialna, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(FontannaMultimedialna, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(WyspaSłodowa, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(WyspaSłodowa, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(ZOO, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(ZOO, OnHandPointerLeave);
            KinectRegion.AddHandPointerEnterHandler(OgródBotaniczny, OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(OgródBotaniczny, OnHandPointerLeave);
        }

    }


}
