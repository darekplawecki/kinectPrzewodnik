using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Przewodnik.Content.Traslations;
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
            StatusLoader.Dispatcher.Invoke(new Action(() => StatusLoader.Text = AppResources.GetText("LOAD_init")));
                
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
                dataLoader.beforeLoaderEvents += BeforeLoaderEvents;
                dataLoader.afterLoaderEvents += AfterLoaderEvents;
                if (dataLoader.EarlyLoad()) LoadEnded(this, new EventArgs());
            }
        }

        private void BeforeLoaderEvents(object sender, EventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                BeforeDataLoaderEventArgs args = eventArgs as BeforeDataLoaderEventArgs;
                StatusWritter(args.Status);
            }
        }

        private void AfterLoaderEvents(object sender, EventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                AfterDataLoaderEventArgs args = eventArgs as AfterDataLoaderEventArgs;
                int percent = args.Many * 100 / args.Of;
                double loaderWidth = args.Many * (double)Application.Current.Resources["LoaderWidth"] / args.Of;
                ProgressUpdater(loaderWidth);
                TextWritter(percent.ToString() + "%");
            }
        }

        public void StatusWritter(String status)
        {
            StatusLoader.Dispatcher.Invoke(new Action(() => StatusLoader.Text = status));
        }

        public void TextWritter(String text)
        {
            PercentLoader.Dispatcher.Invoke(new Action(() => PercentLoader.Text = text));
        }

        public void ProgressUpdater(double width)
        {
            ProgressBar.Dispatcher.Invoke(new Action(() => ProgressBar.Width = width));
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
