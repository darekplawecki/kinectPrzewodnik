using Przewodnik.Views;

namespace Przewodnik
{
    public class Navigator
    {
        private MainWindow mainWindow;

        public Navigator(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void NavigateTo(IKinectPage page)
        {
            mainWindow.SetView(page.GetView());

        }

    }
}
