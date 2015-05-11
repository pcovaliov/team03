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

        public List<TweetModel> Read(int idUser)
        {
            var tweetList = new List<TweetModel>();
            

            foreach (var currentTweet in dbContext.Tweets.Where(selectedTweet => selectedTweet.id_user == idUser))
            {
                tweetList.Add(TweetConverting.ConvertTweetToModel(currentTweet));
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

        public TweetModel GetTweetById(int idTweet)
        {
            TweetModel editedTweet = new TweetModel();
            var tweetEdit =
                dbContext.Tweets.FirstOrDefault(currentTweet => currentTweet.id_tweet.Equals(idTweet));
            if (tweetEdit != null)
            {
                editedTweet.IdTweet = tweetEdit.id_tweet;
                editedTweet.Descripton = tweetEdit.descripton;
                editedTweet.CreatedOn = tweetEdit.created_on;
                return editedTweet;
            }
            return null;

        }

        public bool ChangeTweet(TweetModel currentTweet, int idUser)
        {
            var currentTweetToChange = TweetConverting.ConvertTweetToDAL(currentTweet, idUser);
            var tweetToChange =
                dbContext.Tweets.FirstOrDefault(tweet => tweet.id_tweet == currentTweetToChange.id_tweet);
            if (tweetToChange != null)
            {
                tweetToChange.id_tweet = currentTweetToChange.id_tweet;
                tweetToChange.descripton = currentTweetToChange.descripton;
                tweetToChange.created_on = currentTweetToChange.created_on;
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