using System;
using System.Collections.Generic;
using System.Windows;
using Przewodnik.Views;

namespace Przewodnik
{
    public class Navigator
    {
        private MainWindow mainWindow;
        private Stack<IKinectPage> pagesHistory;

        private IKinectPage mainMenu;
        private SleepScreen sleepScreen;


        public Navigator(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            pagesHistory = new Stack<IKinectPage>();
        }

        public void SetMainMenu(IKinectPage mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public void SetSleepScreen(IKinectPage sleepScreen)
        {
            this.sleepScreen = sleepScreen as SleepScreen;
        }

        public void NavigateTo(IKinectPage page)
        {
            if (page.Equals(mainMenu))
            {
                pagesHistory.Push(page);
                mainWindow.Wake();
                mainWindow.SetView(page.GetView());
                mainWindow.ShowBackButton(false);
            }
            else if (page.Equals(sleepScreen))
            {
                mainWindow.Sleep();
                mainWindow.ShowBackButton(false);
            }
            else
            {
                pagesHistory.Push(page);
                mainWindow.SetView(page.GetView());
                mainWindow.ShowBackButton(true);
            }
        }

        public void GoBack()
        {
            try
            {
                pagesHistory.Pop();
                NavigateTo(pagesHistory.Pop());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void GoSleep()
        {
            NavigateTo(sleepScreen);
        }

        public void GoHome()
        {
            NavigateTo(mainMenu);
            sleepScreen.OpenMainMenu();
        }

    }
}
