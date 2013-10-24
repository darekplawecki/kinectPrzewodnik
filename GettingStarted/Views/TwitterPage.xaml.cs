using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect;
using Przewodnik.Models;
using Przewodnik.Utilities;
using Przewodnik.Views;
using Przewodnik;
using Microsoft.Kinect.Toolkit.Controls;

namespace GettingStarted
{

    partial class TwitterPage : IKinectPage
    {
        private KinectPageFactory pageFactory;
        private TwitterManager twitterManager;
        private List<TweetModel> tweets;
        private String errorMessage;

        public TwitterPage(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            TwitterContent.Text = PrepareTwitterContent2();

        }

        //public string prepareTwitterContent()
        //{
        //    twitterManager = new TwitterManager();
        //    try
        //    {
        //        tweets = twitterManager.GetHomeTimeline();
        //    }
        //    catch (TwitterConnectionException e)
        //    {
        //        return "Connection failed. Try again or ask service for help. Problem detail: " + e.Message;
        //    }
        //}

        public string PrepareTwitterContent2()
        {
            twitterManager = new TwitterManager();
            try
            {
                return twitterManager.GetHomeTimeline2();
            }
            catch (TwitterConnectionException e)
            {
                return "Connection failed. Try again or ask service for help. Problem detail: " + e.Message;
            }
        }

        public Grid GetView()
        {
            return TwitterGrid;
        }

        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            //string parametr = ((KinectTileButton)sender).Name;
            //IKinectPage attractionArticle = pageFactory.GetAttractionArticleGrid(parametr);
            //pageFactory.NavigateTo(attractionArticle);
        }



    }


}
