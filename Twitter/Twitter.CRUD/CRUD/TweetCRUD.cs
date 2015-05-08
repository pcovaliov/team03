using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.DAL;
using Twitter.CRUD.Convertor;
using Twitter.Model;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Twitter.CRUD
{
    public class TweetCRUD
    {
        #region Private
        TweetConvertor TweetConverting;
        twitterEntities dbContext;
        #endregion

        public TweetCRUD()
        {
            TweetConverting = new TweetConvertor();
            dbContext = new twitterEntities();
        }

        public bool AddTweet(TweetModel TweetToAdding, int idUser)
        {          
                    var addTweet = TweetConverting.ConvertTweetToDAL(TweetToAdding, idUser);
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
        public List<TweetModel> Read(int idUser)
        {
            var tweetList = new List<TweetModel>();
            

            foreach (var currentTweet in dbContext.Tweets.Where(selectedTweet => selectedTweet.id_user == idUser))
            {
                tweetList.Add(TweetConverting.ConvertTweetToModel(currentTweet));
            }

            return tweetList;
        }

    }
}