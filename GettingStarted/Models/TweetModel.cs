using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Przewodnik.Models
{
    public class TweetModel : ICloneable
    {
        private String content;

        public String Author { get; set; }

        public DateTime Date
        {
            get;
            set;
        }

        public String Content
        {
            get
            {
                string sourceString = content;
                const string removeString = "http://t.co/";
                int index = sourceString.IndexOf(removeString);
                string cleanPath = (index < 0)
                    ? sourceString
                    : sourceString.Remove(index, 22);
                return cleanPath;
            }

            set
            {
                content = value;
            }
        }

        public String Image { get; set; }
        public List<SolidColorBrush> Colors { get; set; }
        public int Direction { get; set; }

        public object Clone()
        {
            TweetModel cloneTweetModel = new TweetModel();
            cloneTweetModel.Author = this.Author;
            cloneTweetModel.Content = this.Content;
            cloneTweetModel.Date = this.Date;
            cloneTweetModel.Colors = this.Colors;
            cloneTweetModel.Image = this.Image;
            cloneTweetModel.Direction = this.Direction;
            return cloneTweetModel;
        }
    }
}
