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
            //MessageBox.Show("TWORZE SLEEP SREENA");
            InitializeComponent();
            this.pageFactory = pageFactory;
            viewModel = new SleepScreenViewModel();
            viewModel.SleepScreenGrid_Loaded();
            InstagramGrid.DataContext = viewModel.GetCurrentImages();
            /*
            Binding binding = new Binding();
            binding.Mode = BindingMode.OneTime;
            binding.Path = new PropertyPath("CurrentImages[0]");
            AttractCarousel1.SetBinding(ContentControl.ContentProperty, binding);
            */
            
            AttractCarousel1.Content = viewModel.GetCurrentImages()[0];
            AttractCarousel2.Content = viewModel.GetCurrentImages()[1];
            AttractCarousel3.Content = viewModel.GetCurrentImages()[2];
            AttractCarousel4.Content = viewModel.GetCurrentImages()[3];
            AttractCarousel5.Content = viewModel.GetCurrentImages()[4];
            AttractCarousel6.Content = viewModel.GetCurrentImages()[5];
  
        }

        public void OpenMainMenu()
        {
            //MessageBox.Show("OTWIERAM MAIN MENU");
            viewModel.tickTimer.Stop();
            pageFactory.NavigateTo(pageFactory.GetMainMenu());
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }


        private void SleepScreenGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //viewModel.SleepScreenGrid_Loaded();
        }

    }
}

