using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Przewodnik.Models
{
   public class CalendarModel 
    {
        public string Day {get; set;}
        public string Hour { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public SolidColorBrush Color { get; set; }
        public String Icon { get; set; }
       
        public CalendarModel() 
        {
            Day = string.Empty;
            Hour = string.Empty;
            Type = string.Empty;
            Name = string.Empty;
            Place = string.Empty;
            Color = new SolidColorBrush();
            Icon = string.Empty;
        }

        public CalendarModel(string day, string hour, string type, string name, string place, SolidColorBrush Color, string Icon)
        {
            this.Day = day;
            this.Hour = hour;
            this.Type = type;
            this.Name = name;
            this.Place = place;
            this.Color = Color;
            this.Icon = Icon;
        }
    }
}

