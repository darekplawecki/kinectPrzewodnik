using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;

namespace Przewodnik.Models
{
    public class AttractionModel
    {
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        public string Camera { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        public AttractionModel()
        {
            Description = string.Empty;
            Photos = new List<string>();
            Camera = string.Empty;
            Title = string.Empty;
            Color = string.Empty;
            Icon = string.Empty;
        }

        public AttractionModel(string description, List<string> photos, string camera, string title, string color, string icon)
        {
            this.Description = description;
            this.Photos = photos;
            this.Camera = camera;
            this.Title = title;
            this.Color = color;
            this.Icon = icon;
        }

    }
}
