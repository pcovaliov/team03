using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Operations.Convertor
{
    class TweetConvertor
    {
        public Tweet ConvertToDAL(TweetModel convertedTweet)
        {
            Tweet currentTweet = new Tweet();
            currentTweet.id_user = convertedTweet.IdUser;
            currentTweet.descripton = convertedTweet.Descripton;
            currentTweet.created_on = convertedTweet.CreatedOn;
            return currentTweet;
        }

        public TweetModel ConvertToModel(Tweet ConvertedTweet)
        {
            TweetModel currentTweet = new TweetModel();
            currentTweet.IdUser = ConvertedTweet.id_user;
            currentTweet.Descripton = ConvertedTweet.descripton;
            currentTweet.CreatedOn = ConvertedTweet.created_on;
            return currentTweet;
        }
    }
}
