using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Przewodnik.Utilities.Twitter;

namespace Przewodnik.Utilities
{
    class DataLoader
    {
        private InstagramAPIManager _instagramAPI;
        private TwitterManager _twitterAPI;

        public DataLoader()
        {

        }

        public bool Load()
        {
            //LoadInstagram();
            LoadTwitter();
            return true;
        }

        private void LoadInstagram()
        {
            MessageBox.Show("Instagram");
            //_instagramAPI = new InstagramAPIManager();
            //_instagramAPI.saveRecentImages();
        }

        private void LoadTwitter()
        {
            MessageBox.Show("Twitter");
            _twitterAPI = TwitterManager.Instance;
            _twitterAPI.GetHomeTimeline();
        }
    }
}
