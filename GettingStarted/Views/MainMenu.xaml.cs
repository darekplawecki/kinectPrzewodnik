using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class MainMenu : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public MainMenu(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        private void OpenThird(object sender, RoutedEventArgs e)
        {
            pageFactory.NavigateTo(pageFactory.GetThirdGrid());
        }

        public Grid GetView()
        {
            //MessageBox.Show((AnotherGrid == null).ToString());
            return MainMenuGrid;
        }
  
    }


}
