using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xaml;
using Przewodnik.Content.Traslations;
using Przewodnik.Utilities;
using Przewodnik.Controls;
using System.ComponentModel;
using System.Windows.Data;
using Przewodnik.ViewModels;
using Przewodnik.Utilities.DataLoader;

namespace Przewodnik.Views
{

    partial class SleepScreen : IKinectPage
    {

        SleepScreenViewModel viewModel;

        private DispatcherTimer timer;
        private DateTime dt;

        private KinectPageFactory pageFactory;

        public SleepScreen(KinectPageFactory pageFactory)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            Loaded += new RoutedEventHandler(ActualDateTime_Loaded);
            dt = DateTime.Now;
            Time.Text = dt.ToString("HH:mm");
            DayAndMonth.Text = getDayAndMonth();
            WeekDay.Text = getDayOfWeek();
        }

        private void ActualDateTime_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer1_Tick;

            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            Time.Text = dt.ToString("HH:mm");
            DayAndMonth.Text = getDayAndMonth();
            WeekDay.Text = getDayOfWeek();
        }

        private string getDayOfWeek()
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday: return "poniedziałek";
                case DayOfWeek.Tuesday: return "wtorek";
                case DayOfWeek.Wednesday: return "środa";
                case DayOfWeek.Thursday: return "czwartek";
                case DayOfWeek.Friday: return "piątek";
                case DayOfWeek.Saturday: return "sobota";
                case DayOfWeek.Sunday: return "niedziela";
                default: return "";
            }

        }

        private string getDayAndMonth()
        {
            string dayAndMonth = dt.ToString("dd") + " ";

            switch (dt.ToString("MM"))
            {
                case "1": dayAndMonth += "stycznia"; break;
                case "2": dayAndMonth += "lutego"; break;
                case "3": dayAndMonth += "marca"; break;
                case "4": dayAndMonth += "kwietnia"; break;
                case "5": dayAndMonth += "maja"; break;
                case "6": dayAndMonth += "czerwca"; break;
                case "7": dayAndMonth += "lipca"; break;
                case "8": dayAndMonth += "sierpnia"; break;
                case "9": dayAndMonth += "września"; break;
                case "10": dayAndMonth += "października"; break;
                case "11": dayAndMonth += "listopada"; break;
                case "12": dayAndMonth += "grudnia"; break;
                default: break;
            }

            return dayAndMonth;
        }


        public void OpenMainMenu()
        {
            viewModel.tickTimer.Stop();
            pageFactory.NavigateTo(pageFactory.GetMainMenu());
        }

        public Grid GetView()
        {
            return SleepScreenGrid;
        }

        private void SleepScreenGrid_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new SleepScreenViewModel();
            viewModel.InitSleepScreen();
            InstagramGrid.DataContext = viewModel.CurrentImages[0];

            Binding bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage1");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel1, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage2");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel2, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage3");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel3, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage4");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel4, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage5");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel5, ContentControl.ContentProperty, bin);

            bin = new Binding();
            bin.Path = new PropertyPath("CurrentImage6");
            bin.Mode = BindingMode.OneWay;
            BindingOperations.SetBinding(AttractCarousel6, ContentControl.ContentProperty, bin);

        }

        public void OnNavigateTo()
        {
            MapLoader.Instance.FirstRun = true;
        }

        private void EnglishClicked(object sender, RoutedEventArgs e)
        {
            AppResources.SetCultureInfo("en-US");
        }

        private void PolishClicked(object sender, RoutedEventArgs e)
        {
            AppResources.SetCultureInfo("pl-PL");
        }
    }
}

