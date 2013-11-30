using System;
using System.Windows;
using System.Windows.Controls;
using Przewodnik.Content.Traslations;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Views
{

    partial class TwitterPage : IKinectPage
    {
        private KinectPageFactory pageFactory;
        private TwitterManager twitterManager;

        public TwitterPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            PrepareTwitterContent();
        }

        public void PrepareTwitterContent()
        {
            twitterManager = TwitterManager.Instance;
            try
            {
                if (twitterManager.IsError)
                {

                    DealWithError();
                }
                else
                {
                    SetNewContent();
                }
            }
            catch (TwitterConnectionException e)
            {
                ErrorContent.Text = "Błąd w połączeniu :( Spróbuj ponownie później lub poproś obsługę o pomoc.";
                TwitterContent.Text = e.Message;
            }
        }

        private void SetNewContent()
        {
            MainList.ItemsSource = null;
            MainList.ItemsSource = twitterManager.tweets;
        }

        private void DealWithError()
        {
            if (twitterManager.tweets != null)
            {
                SetNewContent();
            }
            else
            {
                ErrorContent.Text = "Błąd w połączeniu :( Spróbuj ponownie później lub poproś obsługę o pomoc.";
                TwitterContent.Text = twitterManager.errorCode;
            }
        }


        public Grid GetView()
        {
            return TwitterGrid;
        }

        private void RefreshIt_Action(object sender, RoutedEventArgs e)
        {
            twitterManager = TwitterManager.Instance;
            twitterManager.GetHomeTimeline();
            PrepareTwitterContent();
        }

        public void OnNavigateTo()
        {
            firstTextBlock.Text = AppResources.GetText("M_z_ostatniej_chwili");
        }
    }


}
