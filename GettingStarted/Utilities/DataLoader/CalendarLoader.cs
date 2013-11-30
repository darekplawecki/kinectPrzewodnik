using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities.DataLoader
{
    class CalendarLoader
    {
        private static CalendarLoader instance;
        public Hashtable WWWSourcesHashtable;
        public EventHandler calendarEventLoaded;

        private CalendarLoader()
        {

        }

        public static CalendarLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CalendarLoader();
                }
                return instance;
            }
        }

        public void LoadEvents()
        {
            CookieAwareWebClient client = new CookieAwareWebClient();
            WWWSourcesHashtable = new Hashtable();

            DateTime dt = new DateTime();
            dt = DateTime.Today;

            for (int i = 0; i < 14; i++)
            {
                string parameter = dt.AddDays(i).ToString("yyyy-MM-dd");
                string link = "http://pik.wroclaw.pl/d" + parameter;
                var result = client.DownloadData(link);
                var html = System.Text.Encoding.Default.GetString(result);

                //string parameter = dt.AddDays(i).ToString("yyyy-MM-dd");
                //StreamReader sr = new StreamReader("C:/Wydarzenie.txt");
                //var html = sr.ReadToEnd();
                //sr.Close();

                WWWSourcesHashtable[parameter] = html;
                moveProgress(i);
            }
        }

        private void moveProgress(int dayLoaded)
        {
            switch (dayLoaded)
            {
                case 2:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(4, 10));
                    break;
                case 4:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(5, 10));
                    break;
                case 6:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(6, 10));
                    break;
                case 8:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(7, 10));
                    break;
                case 10:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(8, 10));
                    break;
                case 12:
                    calendarEventLoaded(this, new AfterDataLoaderEventArgs(9, 10));
                    break;
            }
        }

    }
}
