using System.Globalization;
using Microsoft.Kinect.Toolkit.Controls;
using Przewodnik.Content.Traslations;
using Przewodnik.ViewModels;
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

namespace Przewodnik.Views
{
    public partial class CalendarPage : IKinectPage
    {
        private KinectPageFactory pageFactory;
        private CalendarViewModel viewModel;
        private CalendarViewModel viewModelCopy;
        string FILTER = "";

        public CalendarPage(KinectPageFactory pageFactory, String parameter)
        {
            InitializeComponent();
            this.pageFactory = pageFactory;
            viewModel = new CalendarViewModel(parameter);
            EventList.ItemsSource = null;
            EventList.ItemsSource = viewModel.modelList;
            CalendarList.ItemsSource = GetTwoWeeksButtons();
            titleTextBlock.Text = GetDayWithPointAndDayOfWeek(parameter);
        }

        public List<DateTime> GetTwoWeeksButtons()
        {
            List<DateTime> TwoWeeks = new List<DateTime>();

            DateTime dt = new DateTime();
            dt = DateTime.Today;

            TwoWeeks.Add(dt);
            for (int i = 1; i < 14; i++)
            {
                TwoWeeks.Add(dt.AddDays(i));
            }

            return TwoWeeks;
        }

        public string DateTimeFormat(string parameter)
        {
            string day = parameter.Substring(8, 2);
            string month = parameter.Substring(5, 2);
            string year = parameter.Substring(0, 4);

            DateTime dt = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));

            return dt.ToString("yyyy-MM-dd");
        }

        public string GetDayWithPointAndDayOfWeek(string parameter)
        {
            string day = parameter.Substring(8);
            string month = parameter.Substring(5, 2);
            string year = parameter.Substring(0, 4);
            string dayOfWeek = "";

            DateTime dt = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
            dayOfWeek = dt.ToString("dddd", AppResources.GetCultureInfo());
            return day + "." + month + "." + year + " (" + dayOfWeek + ")";
        }

        public Grid GetView()
        {
            return CalendarGrid;
        }

        private void changeDayButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedDate = ((KinectTileButton)sender).Tag.ToString();
            titleTextBlock.Text = GetDayWithPointAndDayOfWeek(DateTimeFormat(selectedDate));

            viewModel = new CalendarViewModel(DateTimeFormat(selectedDate));

            if (FILTER != "" && FILTER!="Wszystkie")
            {
                viewModelCopy = new CalendarViewModel();
                for (int i = 0; i < viewModel.modelList.Count(); i++)
                {
                    if (viewModel.modelList[i].Type.Equals(FILTER))
                    {
                        viewModelCopy.modelList.Add(viewModel.modelList[i]);
                    }
                }

                EventList.ItemsSource = null;
                EventList.ItemsSource = viewModelCopy.modelList;

                if (viewModelCopy.modelList.Count() == 0)
                {
                    emptyBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    emptyBlock.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                FILTER = "";
                EventList.ItemsSource = null;
                EventList.ItemsSource = viewModel.modelList;
            }
            ScrollViewer.ScrollToTop();
        }

        

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            viewModelCopy = new CalendarViewModel();
            string filter = ((KinectTileButton)sender).Name.ToString();
            FILTER = filter;

            for (int i = 0; i < viewModel.modelList.Count(); i++)
            {
                if (viewModel.modelList[i].Type.Equals(filter))
                {
                    viewModelCopy.modelList.Add(viewModel.modelList[i]);
                }
            }

            EventList.ItemsSource = null;
            EventList.ItemsSource = viewModelCopy.modelList;

            if (viewModelCopy.modelList.Count() == 0)
            {
                emptyBlock.Visibility = Visibility.Visible;
            }
            else
            {
                emptyBlock.Visibility = Visibility.Hidden;
            }

            ScrollViewer.ScrollToTop();
        }

        private void FilterAll_Click(object sender, RoutedEventArgs e)
        {
            emptyBlock.Visibility = Visibility.Hidden;
            FILTER = "";
            EventList.ItemsSource = null;
            EventList.ItemsSource = viewModel.modelList;
            ScrollViewer.ScrollToTop();
        }


        public void OnNavigateTo()
        {
            prepareTranslation();
        }

        private void prepareTranslation()
        {
            DzieciBlock.Text = AppResources.GetText("W_dzieci");
            InneBlock.Text = AppResources.GetText("W_inne");
            KinoBlock.Text = AppResources.GetText("W_kino");
            MuzykaBlock.Text = AppResources.GetText("W_muzyka");
            NaukaBlock.Text = AppResources.GetText("W_nauka");
            TeatrBlock.Text = AppResources.GetText("W_teatr");
            emptyBlock.Text = AppResources.GetText("W_brak_wydarzen");
            WszystkieBlock.Text = AppResources.GetText("W_wszystkie");

        }
    }
}
