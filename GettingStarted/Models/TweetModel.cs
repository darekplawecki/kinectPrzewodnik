using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Models
{
    public class TweetModel : ICloneable
    {
        private String author;
        private DateTime date;
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

        public object Clone()
        {
            TweetModel cloneTweetModel = new TweetModel();
            cloneTweetModel.Author = this.Author;
            cloneTweetModel.Content = this.Content;
            cloneTweetModel.Date = this.Date;
            return cloneTweetModel;
        }
    }
}
