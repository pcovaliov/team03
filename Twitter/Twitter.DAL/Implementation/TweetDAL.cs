using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL
{
    public class TweetDAL : ITweetDAL
    {
        #region Private
        twitterEntities dbContext;
        #endregion

        public TweetDAL() 
        {
            dbContext = new twitterEntities();
        }

        public bool AddTweet(Tweet TweetToAdding)
        {
            dbContext.Tweets.Add(TweetToAdding);
            dbContext.SaveChanges();
            return true;
        }

        public List<Tweet> ReadTweets(int idUser)
        {
            var tweetList = new List<Tweet>();


            foreach (var currentTweet in dbContext.Tweets.Where(selectedTweet => selectedTweet.id_user == idUser))
            {
                tweetList.Add(currentTweet);
            }

            return tweetList;
        }

        public bool DeleteTweet(int idTweet)
        {
            var tweetDeleted =
            dbContext.Tweets.FirstOrDefault(currentTweet => currentTweet.id_tweet.Equals(idTweet));
            if (tweetDeleted != null)
            {
                dbContext.Tweets.Remove(tweetDeleted);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Tweet GetTweetById(int idTweet)
        {
            var tweetEdit =
                dbContext.Tweets.FirstOrDefault(currentTweet => currentTweet.id_tweet.Equals(idTweet));
            if (tweetEdit != null)
            {
                return tweetEdit;
            }
            return null;

        }

        public bool ChangeTweet(Tweet currentTweet)
        {
            var tweetToChange =
                dbContext.Tweets.FirstOrDefault(tweet => tweet.id_tweet == currentTweet.id_tweet);
            if (tweetToChange != null)
            {
                tweetToChange.id_tweet = currentTweet.id_tweet;
                tweetToChange.descripton = currentTweet.descripton;
                tweetToChange.created_on = currentTweet.created_on;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
