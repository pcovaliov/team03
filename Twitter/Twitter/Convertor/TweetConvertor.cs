using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.DAL;
using Twitter.Models;
using Twitter.Convertor;
using Twitter.Controllers;
using System.Web.Mvc;
using System.Web.Http;

namespace Twitter.Convertor
{
    public class TweetConvertor
    {
        public Tweet ConvertTweetToDAL(TweetModel convertedTweet)
        {
            Tweet currentTweet = new Tweet();
            int id = 0;
            currentTweet.descripton = convertedTweet.Descripton;
            HttpContext httpContext = HttpContext.Current;
            if (httpContext.ApplicationInstance.Session.Count > 0) 
            {
                id = int.Parse( httpContext.ApplicationInstance.Session["ID"].ToString());
            }

            currentTweet.id_user = id;
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