﻿using Przewodnik.Views;

namespace Przewodnik
{
    public class KinectPageFactory
    {
        private Navigator navigator;

        private IKinectPage _mainMenu;
        private IKinectPage _sleepScreen;
        private IKinectPage _attractions;
        private IKinectPage _attractionArticle;


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
            if (_attractionArticle == null) _attractionArticle = new AttractionArticle(this);
            return _attractionArticle;
        }

        public void NavigateTo(IKinectPage page)
        {
            navigator.NavigateTo(page);
        }
    }
}
