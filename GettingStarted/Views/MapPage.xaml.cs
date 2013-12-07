using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;
using Przewodnik.ViewModels;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Content.Traslations;
using Przewodnik.Models;
using System;

namespace Przewodnik.Views
{
    partial class MapPage : IKinectPage
    {
        private KinectPageFactory _pageFactory;
        public PlacesViewModel pvm;
        public MapViewModel mvm;

        public MapPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            KinectRegion.AddQueryInteractionStatusHandler(MasterBingMap, OnQuery);
            _pageFactory = pageFactory;

            mvm = new MapViewModel();
            MapGrid.DataContext = mvm;

            
        }

        //Variable to track GripInterationStatus
        bool isGripinInteraction = false;

        private void OnQuery(object sender, QueryInteractionStatusEventArgs handPointerEventArgs)
        {

            //If a grip detected change the cursor image to grip
            if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.Grip)
            {
                isGripinInteraction = true;
                handPointerEventArgs.IsInGripInteraction = true;
            }

           //If Grip Release detected change the cursor image to open
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.GripRelease)
            {
                isGripinInteraction = false;
                handPointerEventArgs.IsInGripInteraction = false;
            }

            //If no change in state do not change the cursor
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.None)
            {
                handPointerEventArgs.IsInGripInteraction = isGripinInteraction;
            }

            handPointerEventArgs.Handled = true;
        }

        public Grid GetView()
        {
            return MapPageGrid;
        }

        public void OnNavigateTo()
        {
            prepareTranslation();
            pvm = new PlacesViewModel();

            cleanMap();
            mvm.defaultLocation();
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


        private void drawPolyline(LocationCollection locations)
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = locations;
            MasterBingMap.Children.Add(polyline);
        }

        private void startLocation(int zoom)
        {
            cleanMap();
            mvm.defaultLocation(zoom);
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            cleanMap();
            mvm.defaultLocation();
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

        private void sciezka1_Click(object sender, RoutedEventArgs e)
        {
            startLocation(15);
            showObjects("B_sciezka", ((KinectTileButton)sender).Background.ToString());
            drawPolyline(pvm.firstPath());
        }

        private void sciezka2_Click(object sender, RoutedEventArgs e)
        {
            startLocation(15);
            showObjects("B_sciezka", ((KinectTileButton)sender).Background.ToString());
            drawPolyline(pvm.secondPath());
        }

        private void sciezka3_Click(object sender, RoutedEventArgs e)
        {
            startLocation(12);
            drawPolyline(pvm.thirdPath());
        }

        private void QuickStartCancel_Click(object sender, RoutedEventArgs e)
        {
            mvm._quickStartStep = 0;
            mvm._loader.FirstRun = false;
            mvm.QuickStartVisibility = Visibility.Hidden;
            mvm.ButtonVisibility = Visibility.Visible;
        }

        private void prepareTranslation()
        {
            koscioly.Text = AppResources.GetText("B_koscioly");
            hotele.Text = AppResources.GetText("B_hotele");
            urzedy.Text = AppResources.GetText("B_urzedy");
            muzea.Text = AppResources.GetText("B_muzea");
            parki.Text = AppResources.GetText("B_parki");
            zakupy.Text = AppResources.GetText("B_zakupy");
            transport.Text = AppResources.GetText("B_transport");
            kina.Text = AppResources.GetText("B_kina");
            teatry.Text = AppResources.GetText("B_teatry");
            centrum.Text = AppResources.GetText("B_centrum");
            atrakcje.Text = AppResources.GetText("B_atrakcje");
            zwiedzanie.Text = AppResources.GetText("B_sciezka_zwiedzanie");
            spacer.Text = AppResources.GetText("B_sciezka_spacer");
            rowerem.Text = AppResources.GetText("B_sciezka_rower");
            pomin.Text = AppResources.GetText("S_Mapa_pominiecie");
        }


    }

}
