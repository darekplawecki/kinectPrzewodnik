using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.ViewModels;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Content.Traslations;

namespace Przewodnik.Views
{
    partial class MapPage : IKinectPage
    {
        private KinectPageFactory _pageFactory;
        public PlacesViewModel pvm;

        public MapPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            _pageFactory = pageFactory;

            pvm = new PlacesViewModel();
        }

        public Grid GetView()
        {
            return MapPageGrid;
        }

        private void addPin(double latitude, double longitude)
        {
            Pushpin pin = new Pushpin();
            pin.Location = new Location(latitude, longitude);
            //pin.Content = number.ToString();
            pin.Background = new SolidColorBrush(Colors.Blue);
            //pin.ToolTip = desc;
            MasterBingMap.Children.Add(pin);
        }

        public void OnNavigateTo()
        {
        }

        private void addCanvas(double latitude, double longitude, string nameOfPlace, string color)
        {
            Canvas canvas = new Canvas();
            canvas.Width = 100;
            canvas.Height = 50;

            MapLayer mapLayer = new MapLayer();
            Location location = new Location() { Latitude = latitude, Longitude = longitude };
            PositionOrigin position = PositionOrigin.BottomLeft;

            System.Windows.Media.Color myColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(color);

            Path path = new Path();
            path.Data = Geometry.Parse("M 0,0 L 20,0 20,40 10,50 0,40 0,0");
            path.Fill = new SolidColorBrush(myColor);
            path.StrokeThickness = 2;

            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 18;
            textBlock.Foreground = new SolidColorBrush(Colors.Black);
            textBlock.Text = nameOfPlace;

            path.Opacity = 0.7;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Thickness margin = path.Margin;
            margin.Right = 5;
            path.Margin = margin;

            stackPanel.Children.Add(path);
            stackPanel.Children.Add(textBlock);

            mapLayer.AddChild(stackPanel, location, position);

            MasterBingMap.Children.Add(mapLayer);
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            Location startLocation = new Location(51.109521, 17.046638);
            MasterBingMap.SetView(startLocation, 14.0f);
        }

        private void cleanMap()
        {
            MasterBingMap.Children.RemoveRange(0, MasterBingMap.Children.Count);
        }

        private void showObjects(string filter, string color)
        {
            for (int i = 0; i < pvm.modelList.Count; i++)
            {
                if (pvm.modelList[i].Category.ToString().Equals(AppResources.GetText(filter)))
                {
                    addCanvas(pvm.modelList[i].Latitude, pvm.modelList[i].Longtitude, pvm.modelList[i].NameOfPlace, color);
                }
            }
        }

        private void hotele_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void atrakcje_turystyczne_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void koscioly_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void kina_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void centra_handlowe_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void muzea_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void parki_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void transport_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void urzedy_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

        private void teatry_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            showObjects(((KinectTileButton)sender).Name.ToString(), ((KinectTileButton)sender).Background.ToString());
        }

    }

}
