using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Przewodnik.Utilities;
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


        public void OnNavigateTo2()
        {
            if (!CheckForInternetConnection()) TextWritter("You don't have die internet");
            else if (LoadEnded != null)
            {
                if (dataLoader.Load()) LoadEnded(this, new EventArgs());
            }
        }

        public void TextWritter(String text)
        {
            firstTextBlock.Dispatcher.Invoke(new Action(() => firstTextBlock.Text += "\r\n" + text));
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
