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

namespace Przewodnik.Utilities.Twitter
{
    public class TwitterManager
    {
        private IToken token;
        private static TwitterManager instance;
        public List<TweetModel> tweets;

        public bool IsError;
        public string errorCode;


        public static TwitterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TwitterManager();
                }
                return instance;
            }
        }

        private TwitterManager()
        {
            token = new Token(
                ConfigurationManager.AppSettings["token_AccessToken"],
                ConfigurationManager.AppSettings["token_AccessTokenSecret"],
                ConfigurationManager.AppSettings["token_ConsumerKey"],
                ConfigurationManager.AppSettings["token_ConsumerSecret"]);

            TokenSingleton.Token = token;
        }



        public void GetHomeTimeline()
        {
            List<TweetModel> tweetsCopy = null;
            if (tweets != null) tweetsCopy = Extension.Clone<TweetModel>(tweets);

            token = new Token(
ConfigurationManager.AppSettings["token_AccessToken"],
ConfigurationManager.AppSettings["token_AccessTokenSecret"],
ConfigurationManager.AppSettings["token_ConsumerKey"],
ConfigurationManager.AppSettings["token_ConsumerSecret"]);
            ITokenUser u;

            try
            {
                u = new TokenUser(token);
                IList<ITweet> homeTimeline = u.GetHomeTimeline(20, true, true);
                tweets = new List<TweetModel>();
                foreach (ITweet tweet in homeTimeline)
                {
                    tweets.Add(new TweetModel
                    {
                        Author = TwitterFollowers.GetFollowerName(tweet.Creator.Id.Value),
                        Date = tweet.CreatedAt,
                        Content = tweet.Text
                    });
                }
                IsError = false;
                errorCode = "";
            }
            catch (Exception e)
            {
                IsError = true;
                errorCode = e.ToString();
                if (tweetsCopy != null) tweets = tweetsCopy;
            }



        }

        public String getLastDate()
        {
            return tweets[0].Date.ToString();
        }
    }
}
