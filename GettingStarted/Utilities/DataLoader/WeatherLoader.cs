using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Przewodnik.ViewModels;

namespace Przewodnik.Utilities.DataLoader
{

    class WeatherLoader
    {
        private static WeatherLoader instance;
        public string html;

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

        public void Refresh()
        {
            CookieAwareWebClient client = new CookieAwareWebClient();
            string link = "http://tvnmeteo.tvn24.pl/pogoda/wroclaw,49413/na-dzis-na-jutro,1.html";
            var result = client.DownloadData(link);
            html = System.Text.Encoding.Default.GetString(result);
        }
               
    }
}





