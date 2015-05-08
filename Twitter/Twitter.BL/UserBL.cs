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
                      UserCrud.Read().Where
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
            return UserCrud.Read();
        }

        public UserModel EditUser(int idUser)
        {
            UserModel editingCurrentUser = new UserModel();
            editingCurrentUser = UserCrud.GetUserById(idUser);
            if (editingCurrentUser != null)
            {
                return editingCurrentUser;
            }
            else
            {
                return null;
            }

        }

        public bool EditUser(UserModel currentUser)
        {
            return UserCrud.ChangeUser(currentUser);

        }

        public bool DeleteUser(int idUser)
        {
            return UserCrud.Delete(idUser);

        }
     
        
      
    }
}
