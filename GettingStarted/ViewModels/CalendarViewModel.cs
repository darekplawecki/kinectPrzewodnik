using System.Collections.Generic;
using System.Linq;
using System.Text;
using Przewodnik.Models;
using System.Text.RegularExpressions;
using Przewodnik.Utilities.DataLoader;
using System.Web;

namespace Przewodnik.ViewModels
{
    public class CalendarViewModel
    {
        public List<CalendarModel> modelList;
        public List<string> hoursList;
        public List<string> typesList;
        public List<string> namesList;
        public List<string> placesList;
        CalendarLoader cl;

        public CalendarViewModel()
        {
            modelList = new List<CalendarModel>();
        }

        public CalendarViewModel(string parameter)
        {
            modelList = new List<CalendarModel>();
            cl = CalendarLoader.Instance;
            string html = cl.WWWSourcesHashtable[parameter].ToString();

            hoursList = GetHours(html);
            typesList = GetTypes(html);
            namesList = GetNames(html);
            placesList = GetPlaces(html);
            AddEvent(parameter);
        }

        public void AddEvent(string parameter)
        {
            for (int i = 0; i < hoursList.Count(); i++)
            {
                modelList.Add(new CalendarModel(parameter, hoursList[i], typesList[i], namesList[i], placesList[i]));
            }
        }

        public static List<string> GetHours(string file)
        {
            List<string> hours = new List<string>();
            string pattern = "<td class=\"t_godzina\" style=\"padding-left: 7px\">(.*?)</td>";
            Match m = Regex.Match(file, @pattern);

            while (m.Success)
            {
                string g = m.Groups[1].ToString();
                if (g.Length > 5)
                {
                    g = g.Substring(g.Length - 5);
                }
                hours.Add(g);
                m = m.NextMatch();
            }
            return hours;
        }

        public static List<string> GetTypes(string file)
        {
            List<string> types = new List<string>();
            string pattern = "<td class=\"t_typ\">(.*?)</td>";
            Match m = Regex.Match(file, @pattern);

            while (m.Success)
            {
                string g = m.Groups[1].ToString();
                types.Add(g);
                m = m.NextMatch();
            }

            return types;
        }

        public static List<string> GetNames(string file)
        {
            List<string> names = new List<string>();
            string pattern = "<td class=\"t_nazwa\">(.*?)title=\"(.*?)\">";
            Match m = Regex.Match(file, @pattern);

            while (m.Success)
            {
                string g = m.Groups[2].ToString();
                names.Add(g);
                m = m.NextMatch();
            }
            for (int i = 0; i < names.Count(); i++)
            {
                byte[] bytes = Encoding.Default.GetBytes(names[i]);
                names[i] = Encoding.UTF8.GetString(bytes);
                names[i] = HttpUtility.HtmlDecode(names[i]);
            }

            return names;
        }

        public static List<string> GetPlaces(string file)
        {
            List<string> places = new List<string>();
            string pattern = "<td class=\"t_miejsce\">(.*?)title=\"(.*?)\">";
            Match m = Regex.Match(file, @pattern);

            while (m.Success)
            {
                string g = m.Groups[2].ToString();
                places.Add(g);
                m = m.NextMatch();
            }
            for (int i = 0; i < places.Count(); i++)
            {
                byte[] bytes = Encoding.Default.GetBytes(places[i]);
                places[i] = Encoding.UTF8.GetString(bytes);
                places[i] = HttpUtility.HtmlDecode(places[i]);
            }
            
            return places;
        }
    }
}
