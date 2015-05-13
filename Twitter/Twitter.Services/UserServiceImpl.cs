using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Convert;
using Twitter.Models;
using Twitter.DAL;

namespace Twitter.Services
{
    public class UserServiceImpl : IUserService
    {
        #region Private
        IUserDAL iUserDal { get; set; }   
        #endregion

        public bool Register(UserModel CurrentUser)
        {
            return iUserDal.AddUser(UserConvertor.ConvertToDAL(CurrentUser));
        }

        public int Login(UserModel UserToLogin)
        {
            var userList =
                      iUserDal.ReadUsers().FirstOrDefault
                      (currentUser => currentUser.email.Equals(UserToLogin.Email)
                          &&
                       currentUser.userPassword.Equals(UserToLogin.UserPassword)
                          );
            if (userList != null)
            {
                return userList.id_user;
            }
            else
            {
                return 0;
            }
        }

        public List<UserModel> SelectUsers()
        {
            List<UserModel> usersList = new List<UserModel>();
            foreach (var currentUser in iUserDal.ReadUsers())
            {
                usersList.Add(UserConvertor.ConvertToModel(currentUser));
            }
            return usersList;
        }

        public UserModel GetUser(int idUser) 
        {
            return UserConvertor.ConvertToModel(iUserDal.GetUserById(idUser));
        }

        public bool EditUser(UserModel currentUser)
        {
            return iUserDal.ChangeUser(UserConvertor.ConvertToDAL(currentUser));
        }

        public bool DeleteUser(int idUser)
        {
            return iUserDal.DeleteUser(idUser);

        }
    }
}
