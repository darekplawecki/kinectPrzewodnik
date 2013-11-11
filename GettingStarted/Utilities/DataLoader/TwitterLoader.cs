using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Utilities.DataLoader
{
    public class TwitterLoader
    {
        private TwitterManager _twitterAPI;
        
        public void LoadTwitter()
        {
            _twitterAPI = TwitterManager.Instance;
            _twitterAPI.GetHomeTimeline();
        }
    }
}
