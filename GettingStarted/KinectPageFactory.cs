using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using Przewodnik.Views;
using GettingStarted;

namespace Przewodnik
{
    public class KinectPageFactory
    {
        private Navigator navigator;

        private IKinectPage _mainMenu;
        private IKinectPage _sleepScreen;
        private IKinectPage _attractions;
        private IKinectPage _attractionArticle;
        private IKinectPage _twitterPage;
        private IKinectPage _calendarPage;
        private IKinectPage _mapPage;
        private IKinectPage _postcardPage;


        public KinectPageFactory(Navigator navigator)
        {
            this.navigator = navigator;
        }

        public IKinectPage GetMainMenu()
        {
            if (_mainMenu == null) _mainMenu = new MainMenu(this);
            return _mainMenu;
        }

        public IKinectPage GetSleepScreen()
        {
            if (_sleepScreen == null) _sleepScreen = new SleepScreen(this);
            return _sleepScreen;
        }

        public IKinectPage GetAttractionsGrid()
        {
            if (_attractions == null) _attractions = new Attractions(this);
            return _attractions;
        }

        public IKinectPage GetAttractionArticleGrid()
        {
            if (_attractionArticle == null) _attractionArticle = new AttractionArticle(this, null);
            return _attractionArticle;
        }

        public IKinectPage GetAttractionArticleGrid(String parameter)
        {
            _attractionArticle = new AttractionArticle(this, parameter);
            return _attractionArticle;
        }

        public IKinectPage GetTwitterPageGrid()
        {
            _twitterPage = new TwitterPage(this);
            return _twitterPage;
        }

        public IKinectPage GetCalendarPageGrid(String parameter)
        {
            _calendarPage = new CalendarPage(this, parameter);
            return _calendarPage;
        }

        public IKinectPage GetMapPageGrid()
        {
            if (_mapPage == null) _mapPage = new MapPage(this);
            return _mapPage;
        }

        public IKinectPage GetPostcardPageGrid()
        {
            if (_postcardPage == null) _postcardPage = new PostcardPage(this);
            return _postcardPage;
        }
        public IKinectPage PostcardPage
        {
            get { return _postcardPage; }
        }

        public IKinectPage GetVideoPlayer()
        {
            return new VideoPlayer(this, navigator);
        }

        public void ShowTopBar(bool show)
        {
            navigator.mainWindow.ShowTopBar(show);
        }

        public void NavigateTo(IKinectPage page)
        {
            navigator.NavigateTo(page);
        }
    }
}
