using System;
namespace Przewodnik.Utilities.DataLoader
{
    class WeatherLoader
    {
        private static WeatherLoader instance;
        public string html;
        public EventHandler loadWeather;

        private WeatherLoader()
        {
            Refresh();
        }

        public static WeatherLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherLoader();
                }
                return instance;
            }
        }

        public void LoadWeather()
        {
            Refresh();
            loadWeather(this, new EventArgs());
        }

        public void Refresh()
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient();
                string link = "http://tvnmeteo.tvn24.pl/pogoda/wroclaw,49413/na-dzis-na-jutro,1.html";
                var result = client.DownloadData(link);
                html = System.Text.Encoding.Default.GetString(result);
            }
            catch (Exception e)
            {
                html = "";
            }

        }
    }
}





