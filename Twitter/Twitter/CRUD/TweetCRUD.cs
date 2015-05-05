using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.DAL;
using Twitter.Convertor;
using Twitter.Models;
using System.Web.SessionState;
namespace Twitter.CRUD
{
    public class TweetCRUD
    {
       twitterEntities dbContext = new twitterEntities();
       TweetConvertor TweetConverting = new TweetConvertor();

        public bool AddTweet(TweetModel TweetToAdding)
        {          
            var addTweet = TweetConverting.ConvertTweetToDAL(TweetToAdding);
            dbContext.Tweets.Add(addTweet);
            dbContext.SaveChanges();
            return true;
        }

        //public bool Delete(TweetModel TweetToDeleting)
        //{          
        //    var deleteTweet = TweetConverting.ConvertTweetToDAL(TweetToDeleting);
        //    var tweetList =
        //              dbContext.Tweets.Where
        //              (currentTweet => currentTweet.id_tweet.Equals(deleteTweet.id_tweet)).
        //              FirstOrDefault();
        //    if (tweetList != null)
        //    {
        //        dbContext.Tweets.Remove(deleteTweet);
        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool Update(TweetModel TweetToUpdate)
        //{          
        //    var updateTweet = TweetConverting.ConvertTweetToDAL(TweetToUpdate);
        //    var tweetList =
        //              dbContext.Tweets.Select(currentTweet => currentTweet);
        //    if (tweetList != null)
        //    {
        //        dbContext.Tweets.Where
        //              (currentTweet => currentTweet.id_tweet.Equals(updateTweet.id_tweet)).First().descripton = updateTweet.descripton;
        //        dbContext.Tweets.Where
        //              (currentTweet => currentTweet.id_tweet.Equals(updateTweet.id_tweet)).First().created_on = updateTweet.created_on;
        //        dbContext.Tweets.Where
        //              (currentTweet => currentTweet.id_tweet.Equals(updateTweet.id_tweet)).First().id_user = updateTweet.id_user;
        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public List<TweetModel> Read()
        //{          
        //    var tweetList = new List<TweetModel>();

        //    foreach (var currentTweet in dbContext.Tweets)
        //    {
        //        tweetList.Add(TweetConverting.ConvertTweetToModel(currentTweet));
        //    }

        //    return tweetList;
        //}

    }
}
