using Przewodnik.Models;
using Przewodnik.Utilities.DataLoader;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System;

namespace Przewodnik.ViewModels
{
    public class WeatherViewModel : ViewModelBase
    {
        public WeatherModel wm;
        public DispatcherTimer timer;

        private int state;
        public int WeatherState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("WeatherState");
            }
        }

        public WeatherViewModel()
        {
            WeatherLoader wl = WeatherLoader.Instance;
            wm = new WeatherModel();
            wm.WeatherImage = wl.html != "" ? GetWheatherImage(wl.html) : "../Content/Weather/ico4.png";
            wm.Temperature = wl.html != "" ? GetTemperature(wl.html) : "-°";
            WeatherState = 0;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += ChangeState;

            timer.Start();
        }

        private void ChangeState(object sender, EventArgs e)
        {
            if (WeatherState == 0)
                WeatherState = 1;
            else
                WeatherState = 0;
        }

        public static string GetWheatherImage(string file)
        {
            string pattern = "<span class=\"city_49413_icon weatherIco size40x40 (.*?)\"></span>";
            Match m = Regex.Match(file, @pattern);
            string weatherImage = "";

            if (m.Success)
            {
                weatherImage = m.Groups[1].ToString();
            }
            return "../Content/Weather/" + weatherImage + ".png";
        }

        public static string GetTemperature(string file)
        {
            string pattern = "<span class=\"city_temperature city_49413_temperature\">(.*?)</span>";
            Match m = Regex.Match(file, @pattern);
            string temperature = "";

            if (m.Success)
            {
                temperature = m.Groups[1].ToString();
            }
            return temperature + "°";
        }

    }
}
