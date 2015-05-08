using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.CRUD.Convertor;
using System.Web;

using Twitter.Model;

namespace Twitter.CRUD.Convertor
{
    public class TweetConvertor
    {
        public Tweet ConvertTweetToDAL(TweetModel convertedTweet, int idUser)
        {
            Tweet currentTweet = new Tweet();
            currentTweet.descripton = convertedTweet.Descripton;
            currentTweet.created_on = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            currentTweet.id_user = idUser;
            return currentTweet;
        }

        public TweetModel ConvertTweetToModel(Tweet convertedTweet)
        {
            TweetModel currentTweet = new TweetModel();
            currentTweet.Descripton = convertedTweet.descripton;
            currentTweet.IdUser = convertedTweet.id_user ?? 1;
            currentTweet.CreatedOn = convertedTweet.created_on;
            currentTweet.IdTweet = convertedTweet.id_tweet;
            return currentTweet;
        }
    }
}
