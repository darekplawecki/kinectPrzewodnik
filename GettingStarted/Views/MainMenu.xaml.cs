using System.Windows;
using System.Windows.Controls;
using Przewodnik.Converters;
using System;
using Przewodnik.Content.Traslations;
using Przewodnik.ViewModels;
using Przewodnik.Utilities.Twitter;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Data;

namespace Przewodnik.Views
{

    partial class MainMenu : IKinectPage, INotifyPropertyChanged
    {
        private KinectPageFactory pageFactory;

        private TwitterManager twitterManager;
        public DispatcherTimer timer;

        public MainMenu(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;

            TwitterGrid.DataContext = this;

            twitterManager = TwitterManager.Instance;
            LoadTweets();
        }

        public Grid GetView()
        {
            return MainMenuGrid;
        }

        public void OnNavigateTo()
        {
            prepareTranslation();
        }

        private void touristAttractions_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage attractions = pageFactory.GetAttractionsGrid();
            pageFactory.NavigateTo(attractions);
        }

        private void twitterPageButton_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage twitterPage = pageFactory.GetTwitterPageGrid();
            pageFactory.NavigateTo(twitterPage);
        }

        private void calendarPageButton_Click(object sender, RoutedEventArgs e)
        {
            string parameter = DateTime.Now.ToString("yyyy-MM-dd");
            IKinectPage calendarPage = pageFactory.GetCalendarPageGrid(parameter);
            pageFactory.NavigateTo(calendarPage);
        }

        private void mapPageButton_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage mapPage = pageFactory.GetMapPageGrid();
            pageFactory.NavigateTo(mapPage);
        }

        private void postcardPageButton_Click(object sender, RoutedEventArgs e)
        {
            IKinectPage postcardPage = pageFactory.GetPostcardPageGrid();
            pageFactory.NavigateTo(postcardPage);
        }

        private void prepareTranslation()
        {
            Atrakcje.Text = AppResources.GetText("M_atrakcje_turystyczne");
            Atrakcje_opis.Text = AppResources.GetText("M_atrakcje_turystyczne_description");
            Wydarzenia.Text = AppResources.GetText("M_wydarzenia");
            Twitter.Text = AppResources.GetText("M_twitter");
            Pogoda.Text = AppResources.GetText("M_pogoda");
            Mapy.Text = AppResources.GetText("M_plan_miasta");
            Widokowka.Text = AppResources.GetText("M_widokowka");
            
        }

        public void LoadTweets()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            twitterManager.GetHomeTimeline();

            int counter = 0;
            IValueConverter dateConverter = new Przewodnik.Converters.DateTimeConverter();

            if (twitterManager.tweets != null)
            {
                Debug.WriteLine("dupa");
                Debug.WriteLine("HELLO @" + twitterManager.GetHomeTweet(counter).Author);
                Author_1.Text = "@" + twitterManager.GetHomeTweet(counter).Author;
                Content_1.Text = twitterManager.GetHomeTweet(counter).Content;
                Date_1.Text = dateConverter.Convert(twitterManager.GetHomeTweet(counter).Date, GetType(), null, null).ToString();
                TwitterState = 1;

                timer.Tick += (s, e) =>
                {
                    if (++counter > 4) counter = 0;
                    if (TwitterState == 1)
                    {
                        Author_1.Text = "@" + twitterManager.GetHomeTweet(counter).Author;
                        Content_1.Text = twitterManager.GetHomeTweet(counter).Content;
                        Date_1.Text = dateConverter.Convert(twitterManager.GetHomeTweet(counter).Date, GetType(), null, null).ToString();
                        TwitterState = 2;
                    }
                    else
                    {
                        Author_2.Text = "@" + twitterManager.GetHomeTweet(counter).Author;
                        Content_2.Text = twitterManager.GetHomeTweet(counter).Content;
                        Date_2.Text = dateConverter.Convert(twitterManager.GetHomeTweet(counter).Date, GetType(), null, null).ToString();
                        TwitterState = 1;
                    }
                };

                timer.Start();
            }
        }

        public int state;
        public int TwitterState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("TwitterState");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }


}
