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
        public Tweet ConvertTweetToDAL(TweetModel convertedTweet)
        {
            Tweet currentTweet = new Tweet();
            int id = 1;
            currentTweet.descripton = convertedTweet.Descripton;
            currentTweet.created_on = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            currentTweet.id_tweet = convertedTweet.IdTweet;
            //HttpContext httpContext = HttpContext.Current;
            //if (httpContext.ApplicationInstance.Session.Count > 0)
            //{
            //    id = int.Parse(httpContext.ApplicationInstance.Session["ID"].ToString());
            //}

            currentTweet.id_user = id;
            return currentTweet;
        }

        public TweetModel ConvertTweetToModel(Tweet convertedTweet)
        {
            TweetModel currentTweet = new TweetModel();
            currentTweet.Descripton = convertedTweet.descripton;
            currentTweet.IdUser = convertedTweet.id_user ?? 1;
            currentTweet.CreatedOn = convertedTweet.created_on;
            return currentTweet;
        }
    }
}
