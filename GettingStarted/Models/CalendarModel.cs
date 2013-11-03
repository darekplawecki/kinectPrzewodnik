using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Models
{
   public class CalendarModel 
    {
        public string Day {get; set;}
        public string Hour { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
       
        public CalendarModel() 
        {
            Day = string.Empty;
            Hour = string.Empty;
            Type = string.Empty;
            Name = string.Empty;
            Place = string.Empty;
        }

        public CalendarModel(string day, string hour, string type, string name, string place)
        {
            this.Day = day;
            this.Hour = hour;
            this.Type = type;
            this.Name = name;
            this.Place = place;
        }
    }
}

