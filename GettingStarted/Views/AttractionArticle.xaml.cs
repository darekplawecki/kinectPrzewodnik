using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using Przewodnik.ViewModels;
using System.Windows.Media.Imaging;
using Microsoft.Kinect.Toolkit.Controls;

namespace Przewodnik.Views
{

    partial class AttractionArticle : IKinectPage
    {
        
        private KinectPageFactory pageFactory;
        private AttractionViewModel viewModel;


        public Grid GetView()
        {
            return AttractionArticleGrid;
        }


        public AttractionArticle(KinectPageFactory pageFactory, String parameter)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            viewModel = new AttractionViewModel(parameter);
            AttractionArticleGrid.DataContext = viewModel.GetModel();

            SetBigImage(viewModel.GetModel().Photos[0], 1);
            firstImageSource.Source = new BitmapImage(new Uri(viewModel.GetModel().Photos[0], UriKind.Relative));
            secondImageSource.Source = new BitmapImage(new Uri(viewModel.GetModel().Photos[1], UriKind.Relative));
            thirdImageSource.Source = new BitmapImage(new Uri(viewModel.GetModel().Photos[2], UriKind.Relative));
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {
            switch (((KinectTileButton)sender).Name)
            {
                case "FirstImageButton":
                    SetBigImage(viewModel.GetModel().Photos[0], 1);
                    break;
                case "SecondImageButton":
                    SetBigImage(viewModel.GetModel().Photos[1], 2);
                    break;
                case "ThirdImageButton":
                    SetBigImage(viewModel.GetModel().Photos[2], 3);
                    break;
                default:
                    SetBigImage(viewModel.GetModel().Photos[0], 1);
                    break;
            }

        }

        private void SetBigImage(string source, int index)
        {
            bigImageGrid.Children.Clear();
            
            if (index != 3 || viewModel.GetModel().Camera == null)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(source, UriKind.Relative));
                image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                image.HorizontalAlignment = HorizontalAlignment.Left;

                bigImageGrid.Children.Add(image);
            }
            else
            {
                Frame frame = new Frame();

                //string projectPath = Environment.CurrentDirectory;
                //projectPath = projectPath.Substring(0, projectPath.Length - 9);

                frame.Source = new Uri("C:/Users/Prezes/Documents/GitHub/kinectPrzewodnik/GettingStarted/Content/Cameras/Rynek.htm", UriKind.Relative);

                bigImageGrid.Children.Add(frame);
            }
        }
    }
}