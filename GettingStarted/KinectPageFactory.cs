using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using Przewodnik.Views;

namespace Przewodnik
{
    public class KinectPageFactory
    {
        private Navigator navigator;

        private IKinectPage _mainMenu;
        private IKinectPage _sleepScreen;
        private IKinectPage secondPage;
        private IKinectPage thirdPage;


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



        public IKinectPage GetSecondGrid()
        {
            if(secondPage == null) secondPage = new SecondPage(this);
            return secondPage;
        }

        public IKinectPage GetThirdGrid()
        {
            if (thirdPage == null) thirdPage = new ThirdPage(this);
            return thirdPage;
        }

        public void NavigateTo(IKinectPage page)
        {
            navigator.NavigateTo(page);
        }
    }
}
