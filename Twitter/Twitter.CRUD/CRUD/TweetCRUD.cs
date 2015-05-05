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

        private TweetConvertor TweetConverting = new TweetConvertor();

        public bool AddTweet(TweetModel TweetToAdding)
        {
            try
            {
                using (twitterEntities dbContext = new twitterEntities())
                {
                    var addTweet = TweetConverting.ConvertTweetToDAL(TweetToAdding);
                    dbContext.Tweets.Add(addTweet);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
                return false;
            } 
        }

        public bool Delete(TweetModel TweetToDeleting)
        {
            twitterEntities dbContext = new twitterEntities();
            TweetConvertor TweetConverting = new TweetConvertor();
            var deleteTweet = TweetConverting.ConvertTweetToDAL(TweetToDeleting);
            var tweetList =
                      dbContext.Tweets.Where
                      (currentTweet => currentTweet.id_tweet.Equals(deleteTweet.id_tweet)).
                      FirstOrDefault();
            if (tweetList != null)
            {
                dbContext.Tweets.Remove(deleteTweet);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<TweetModel> Read()
        {
            twitterEntities dbContext = new twitterEntities();
            TweetConvertor TweetConverting = new TweetConvertor();
            var tweetList = new List<TweetModel>();

            foreach (var currentTweet in dbContext.Tweets)
            {
                tweetList.Add(TweetConverting.ConvertTweetToModel(currentTweet));
            }

            return tweetList;
        }

    }
}