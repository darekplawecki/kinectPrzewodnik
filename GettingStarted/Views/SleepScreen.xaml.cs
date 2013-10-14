using System.Windows;
using System.Windows.Controls;

namespace Przewodnik.Views
{

    partial class SleepScreen : IKinectPage
    {
        private KinectPageFactory pageFactory;

        public SleepScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }
  
    }


}
