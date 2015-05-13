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
    public class TweetServiceImpl : ITweetService
    {
        #region Private
        ITweetDAL iTweetDal { get; set; }
        #endregion

        public List<TweetModel> SelectTweets(int idUser)
        {
            List<TweetModel> tweetsList = new List<TweetModel>();
            foreach (var currentTweet in iTweetDal.ReadTweets(idUser)) 
            {
                tweetsList.Add(TweetConvertor.ConvertTweetToModel(currentTweet));
            }
            return tweetsList;
        }

        public bool Message(TweetModel CurrentTweet, int idUser)
        {
            if (iTweetDal.AddTweet(TweetConvertor.ConvertTweetToDAL(CurrentTweet, idUser)))
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
            return iTweetDal.DeleteTweet(idTweet);
        }

        public TweetModel GetTweet(int idTweet) 
        {
            return TweetConvertor.ConvertTweetToModel(iTweetDal.GetTweetById(idTweet));
        }

        public bool EditTweet(TweetModel currentTweet, int idUser)
        {
            return iTweetDal.ChangeTweet(TweetConvertor.ConvertTweetToDAL(currentTweet, idUser));
        }
    }
}
