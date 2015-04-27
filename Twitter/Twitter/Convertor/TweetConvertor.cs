using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Convertor
{
    public class TweetConvertor
    {
        public Tweet ConvertTweetToDAL(TweetModel convertedTweet)
        {
            Tweet currentTweet = new Tweet();
            currentTweet.descripton = convertedTweet.Descripton;
            currentTweet.id_user = convertedTweet.IdUser;
            return currentTweet;
        }

        public TweetModel ConvertTweetToModel(Tweet convertedTweet)
        {
            TweetModel currentTweet = new TweetModel();
            currentTweet.Descripton = convertedTweet.descripton;
            currentTweet.IdUser = convertedTweet.id_user;
            currentTweet.CreatedOn = convertedTweet.created_on;
            return currentTweet;
        }

    }
}