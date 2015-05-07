using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Model;
using Twitter.DAL;
using Twitter.CRUD.Convertor;
using Twitter.CRUD.CRUD;
using Twitter.CRUD;

namespace Twitter.BL
{
  public class UserBL
    {
      public bool Register(UserModel CurrentUser) 
      {
        UserCRUD AddingUser = new UserCRUD();
        if (AddingUser.AddUser(CurrentUser))
        {
            return true;
        }
        else
        {
            return false;
        }
      }

        public int Login(UserModel UserToLogin)
        {
            UserCRUD readingUsers = new UserCRUD();
            UserConvertor UserConverting = new UserConvertor();
            var userList =
                      readingUsers.Read().Where
                      (currentUser => currentUser.Email.Equals(UserToLogin.Email)
                          &&
                       currentUser.UserPassword.Equals(UserToLogin.UserPassword)
                          ).FirstOrDefault();
            if (userList != null)
            {
                return userList.IdUser;
            }
            else
            {
                return 0;
            }
        }

        public List<UserModel> SelectUsers()
        {
            UserCRUD readingUsers = new UserCRUD();

            return readingUsers.Read();
        }

        public bool Message(TweetModel CurrentTweet)
        {
            TweetCRUD AddingTweet = new TweetCRUD();
            if (AddingTweet.AddTweet(CurrentTweet))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
      
    }
}
