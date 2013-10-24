using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Przewodnik.Models;
using TweetinCore;
using TweetinCore.Interfaces;
using TweetinCore.Interfaces.TwitterToken;
using Tweetinvi;
using TwitterToken;
using System.Configuration;

namespace Przewodnik.Utilities
{
    internal class TwitterManager
    {
        private IToken token;

        public TwitterManager()
        {
            token = new Token(
                ConfigurationManager.AppSettings["token_AccessToken"],
                ConfigurationManager.AppSettings["token_AccessTokenSecret"],
                ConfigurationManager.AppSettings["token_ConsumerKey"],
                ConfigurationManager.AppSettings["token_ConsumerSecret"]);

            TokenSingleton.Token = token;
        }

        public String GetHomeTimeline2()
        {
            ITokenUser u;
            IList<ITweet> homeTimeline;
            try
            {
                u = new TokenUser(token);
                homeTimeline = u.GetHomeTimeline(20, true, true);
            }
            catch (Exception e)
            {
                throw new TwitterConnectionException(e.Message);
            }
            


            String result = "";
            foreach (ITweet tweet in homeTimeline)
            {
                result+=(tweet.Creator.Id + "\n " + tweet.Text);
            }
            return result;
        }

        public List<TweetModel> GetHomeTimeline()
        {
            ITokenUser u;
            IList<ITweet> homeTimeline;
            try
            {
                u = new TokenUser(token);
                homeTimeline = u.GetHomeTimeline(20, true, true);
            }
            catch (Exception e)
            {
                throw new TwitterConnectionException(e.Message);
            }


            List<TweetModel> tweets = new List<TweetModel>();
            foreach (ITweet tweet in homeTimeline)
            {
                tweets.Add(new TweetModel
                {
                    author = tweet.Creator.Id.ToString(),
                    date = tweet.CreatedAt,
                    content = tweet.Text
                });
            }
            return tweets;
        }

    }
}
