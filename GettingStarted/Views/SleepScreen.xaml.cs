using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xaml;
using Przewodnik.Utilities;
using Przewodnik.Controls;
using System.ComponentModel;
using System.Windows.Data;
using Przewodnik.ViewModels;

namespace Przewodnik.Views
{
    
    partial class SleepScreen : IKinectPage
    {

        SleepScreenViewModel viewModel;

        private KinectPageFactory pageFactory;

        public SleepScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        public void OpenMainMenu()
        {
            viewModel.tickTimer.Stop();
            pageFactory.NavigateTo(pageFactory.GetMainMenu());
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }

        private void SleepScreenGrid_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new SleepScreenViewModel();
            viewModel.InitSleepScreen();
            InstagramGrid.DataContext = viewModel.CurrentImages[0];

            Binding bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage1");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel1, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage2");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel2, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage3");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel3, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage4");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel4, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage5");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel5, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage6");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel6, ContentControl.ContentProperty, bin);
            
        }

    }
}

