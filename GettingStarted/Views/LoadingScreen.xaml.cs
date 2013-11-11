using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Przewodnik.Utilities;
using Przewodnik.Utilities.DataLoader;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Views
{

    partial class LoadingScreen : IKinectPage
    {
        private KinectPageFactory pageFactory;
        DataLoader dataLoader;

        public event EventHandler LoadEnded;

        public LoadingScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            dataLoader = new DataLoader();
        }

        public Grid GetView()
        {
            return TwitterGrid;
        }

        public void StartLoading()
        {
            if (!CheckForInternetConnection())
            {
                LoadEnded(this, null);
            }
            else if (LoadEnded != null)
            {
                dataLoader.loaderEvents += LoaderEvents;
                if (dataLoader.Load()) LoadEnded(this, new EventArgs());
            }
        }

        private void LoaderEvents(object sender, EventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                DataLoaderEventArgs args = eventArgs as DataLoaderEventArgs;
                int percent = args.Many*100/args.Of;
                TextWritter(percent.ToString()+"%");
            }
        }

        public void TextWritter(String text)
        {
            firstTextBlock.Dispatcher.Invoke(new Action(() => firstTextBlock.Text = text));
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



        public void OnNavigateTo()
        {

        }
    }


}
