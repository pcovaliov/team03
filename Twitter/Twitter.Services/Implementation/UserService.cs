using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Convert;
using Twitter.Models;
using Twitter.DAL;
using log4net;

namespace Twitter.Services
{
    public class UserService : IUserService
    {
        #region Declaration
        public IUserDAL UserDal { get; set; }
        #endregion

        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(UserService));

        public bool Register(UserModel CurrentUser)
        {
            try
            {
                return UserDal.AddUser(UserConvertor.ConvertToDAL(CurrentUser));
            }
            catch (Exception ex)
            {
                log.Error("Error in registration!", ex);
                throw;
            }

        }

        public UserModel Login(UserModel UserToLogin)
        {
            try
            {
                var userList =
                          UserDal.ReadUsers().FirstOrDefault
                          (currentUser => currentUser.email.Equals(UserToLogin.Email)
                              &&
                           currentUser.userPassword.Equals(UserToLogin.UserPassword)
                              );
                if (userList != null)
                {
                    return UserConvertor.ConvertToModel(userList);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in Login!", ex);
                throw;
            }
        }

        public List<UserModel> SelectUsers()
        {
            List<UserModel> usersList = new List<UserModel>();
            foreach (var currentUser in UserDal.ReadUsers())
            {
                if (currentUser.email != "admin@endava.com")
                {
                    usersList.Add(UserConvertor.ConvertToModel(currentUser));
                }
            }
            return usersList;
        }

        public UserModel GetUser(int idUser)
        {
            try
            {
                return UserConvertor.ConvertToModel(UserDal.GetUserById(idUser));
            }
            catch (Exception ex)
            {
                log.Error("Failed to get user", ex);
                throw;
            }
        }

        public bool EditUser(UserModel currentUser)
        {
            try
            {
                return UserDal.ChangeUser(UserConvertor.ConvertToDAL(currentUser));
            }
            catch (Exception ex)
            {
                log.Error("Failed to edit user", ex);
                throw;
            }
        }

        public bool DeleteUser(int idUser)
        {
            try
            {
                return UserDal.DeleteUser(idUser);
            }
            catch (Exception ex)
            {
                log.Error("Failed to delete user", ex);
                throw;
            }

        }
    }
}
