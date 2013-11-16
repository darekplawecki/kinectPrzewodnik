using Przewodnik.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class PostcardPage : IKinectPage
    {
        private KinectPageFactory pageFactory;

        private KinectController _kinectController;


        public PostcardPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;

            _kinectController = MainWindow.KinectController;
            _kinectController.PropertyChanged += KinectControllerPropertyChanged;
        }

        private void KinectControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MaskedColor.Source = _kinectController.ForegroundBitmap;
        }

        public Grid GetView()
        {
            return PostcardGrid;
        }

        public void OnNavigateTo()
        {
        }
    }


}
