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
    public class UserService : IUserService
    {
        #region Declaration
        public IUserDAL UserDal { get; set; }
        #endregion

        public bool Register(UserModel CurrentUser)
        {
            try
            {
                return UserDal.AddUser(UserConvertor.ConvertToDAL(CurrentUser));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Login(UserModel UserToLogin)
        {
            var userList =
                      UserDal.ReadUsers().FirstOrDefault
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
            foreach (var currentUser in UserDal.ReadUsers())
            {
                usersList.Add(UserConvertor.ConvertToModel(currentUser));
            }
            return usersList;
        }

        public UserModel GetUser(int idUser)
        {
            return UserConvertor.ConvertToModel(UserDal.GetUserById(idUser));
        }

        public bool EditUser(UserModel currentUser)
        {
            return UserDal.ChangeUser(UserConvertor.ConvertToDAL(currentUser));
        }

        public bool DeleteUser(int idUser)
        {
            return UserDal.DeleteUser(idUser);

        }
    }
}
