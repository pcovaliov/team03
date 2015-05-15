using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Convert;
using Twitter.Models;
using Twitter.DAL;
using log4net;

namespace Twitter.Services
{
    public class TweetService : ITweetService
    {
        #region Private
        public ITweetDAL TweetDal { get; set; }
        #endregion

        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(TweetService));

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
            try
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
            catch (Exception ex)
            {
                log.Error("Error in adding tweet", ex);
                throw;
            }
        }

        public bool DeleteTweet(int idTweet)
        {
            try
            {
                return TweetDal.DeleteTweet(idTweet);
            }
            catch (Exception ex)
            { 
                log.Error("Error in deleting tweet!", ex);
                throw;
            }
        }

        public TweetModel GetTweet(int idTweet) 
        {
            try
            {
                return TweetConvertor.ConvertTweetToModel(TweetDal.GetTweetById(idTweet));
            }
            catch (Exception ex)
            {
                log.Error("Cannot get tweet by ID", ex);
                throw;
            }
        }

        public bool EditTweet(TweetModel currentTweet, int idUser)
        {
            try
            {
                return TweetDal.ChangeTweet(TweetConvertor.ConvertTweetToDAL(currentTweet, idUser));
            }
            catch (Exception ex)
            {
                log.Error("Error in editing tweets!", ex);
                throw;
            }
        }
    }
}
