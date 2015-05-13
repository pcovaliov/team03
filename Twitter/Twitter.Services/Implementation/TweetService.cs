using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Convert;
using Twitter.Models;
using Twitter.DAL;

namespace Twitter.Services
{
    public class TweetService : ITweetService
    {
        #region Private
        public ITweetDAL TweetDal { get; set; }
        #endregion

        public List<TweetModel> SelectTweets(int idUser)
        {
            List<TweetModel> tweetsList = new List<TweetModel>();
            foreach (var currentTweet in TweetDal.ReadTweets(idUser)) 
            {
                tweetsList.Add(TweetConvertor.ConvertTweetToModel(currentTweet));
            }
            return tweetsList;
        }

        public bool Message(TweetModel CurrentTweet, int idUser)
        {
            if (TweetDal.AddTweet(TweetConvertor.ConvertTweetToDAL(CurrentTweet, idUser)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTweet(int idTweet)
        {
            return TweetDal.DeleteTweet(idTweet);
        }

        public TweetModel GetTweet(int idTweet) 
        {
            return TweetConvertor.ConvertTweetToModel(TweetDal.GetTweetById(idTweet));
        }

        public bool EditTweet(TweetModel currentTweet, int idUser)
        {
            return TweetDal.ChangeTweet(TweetConvertor.ConvertTweetToDAL(currentTweet, idUser));
        }
    }
}
