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
            TweetModel currentTweet = new TweetModel();
            currentTweet.Descripton = convertedTweet.descripton;
            //currentTweet.IdUser = convertedTweet.id_user ?? 1;
            //currentTweet.CreatedOn = convertedTweet.created_on;
            currentTweet.IdUser = convertedTweet.id_user;

            currentTweet.CreatedOn.AddYears(convertedTweet.created_on.Value.Year);
            currentTweet.CreatedOn.AddMonths(convertedTweet.created_on.Value.Month);
            currentTweet.CreatedOn.AddDays(convertedTweet.created_on.Value.Day);
            currentTweet.CreatedOn.AddHours(convertedTweet.created_on.Value.Hour);
            currentTweet.CreatedOn.AddMinutes(convertedTweet.created_on.Value.Minute);
            currentTweet.CreatedOn.AddSeconds(convertedTweet.created_on.Value.Second);

            currentTweet.IdTweet = convertedTweet.id_tweet;
            return currentTweet;
        }
    }
}
