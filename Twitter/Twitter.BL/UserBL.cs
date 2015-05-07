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
      #region Private
      UserCRUD UserCrud;
      TweetCRUD TweetCrud;
      #endregion

      public UserBL()
      {
          UserCrud = new UserCRUD();
          TweetCrud = new TweetCRUD();
      }

      public bool Register(UserModel CurrentUser) 
      {
          return UserCrud.AddUser(CurrentUser);
      }

        public int Login(UserModel UserToLogin)
        {
            var userList =
                      UserCrud.Read().First
                      (currentUser => currentUser.Email.Equals(UserToLogin.Email)
                          &&
                       currentUser.UserPassword.Equals(UserToLogin.UserPassword)
                          );
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
            return UserCrud.Read();
        }

        public bool Message(TweetModel CurrentTweet)
        {
            return TweetCrud.AddTweet(CurrentTweet);   
        }
      
    }
}
