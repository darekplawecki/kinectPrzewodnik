using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities.DataLoader
{
    class CalendarLoader
    {
        private static CalendarLoader instance;
        public Hashtable WWWSourcesHashtable;

        private CalendarLoader()
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
                               
                WWWSourcesHashtable[parameter] = html;
            }
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

    }
}
