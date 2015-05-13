
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Convert
{
    public static class TweetConvertor
    {
        public static Tweet ConvertTweetToDAL(TweetModel convertedTweet, int idUser)
        {
            Tweet currentTweet = new Tweet();
            currentTweet.descripton = convertedTweet.Descripton;
            currentTweet.created_on = DateTime.Now;
            currentTweet.id_user = idUser;
            currentTweet.id_tweet = convertedTweet.IdTweet;
            return currentTweet;
        }

        public static TweetModel ConvertTweetToModel(Tweet convertedTweet)
        {
            TweetModel currentTweet = new TweetModel()
            {

                Descripton = convertedTweet.descripton,
                IdUser = convertedTweet.id_user,
                CreatedOn = DateTime.Parse(convertedTweet.created_on.ToString()),
                IdTweet = convertedTweet.id_tweet
            };
            return currentTweet;
        }
    }
}
