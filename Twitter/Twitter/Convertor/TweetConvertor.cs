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
        public Tweet ConvertToDAL(TweetModel convertedUser)
        {
            Tweet currentUser = new Tweet();
            currentUser.descripton = convertedUser.Descripton;
            currentUser.id_user = convertedUser.IdUser;

            return currentUser;
        }

        public TweetModel ConvertToModel(Tweet ConvertedUser)
        {
            TweetModel currentUser = new TweetModel();
            currentUser.Descripton = ConvertedUser.descripton;
            currentUser.IdUser = ConvertedUser.id_user;
            currentUser.CreatedOn = ConvertedUser.created_on;
            return currentUser;
        }
    }
}