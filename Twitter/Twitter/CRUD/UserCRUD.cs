using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twitter.DAL;
using Twitter.Models;
using Twitter.Convertor;
namespace Twitter.CRUD
{
    public class UserCRUD
    {
        private twitterEntities dbContext = new twitterEntities();
       private UserConvertor UserConverting = new UserConvertor();


        public bool AddUser(UserModel UserToAdding)
        {
            
            var addUser = UserConverting.ConvertToDAL(UserToAdding);
            var userList =
                       dbContext.Users.Where
                       (currentUser => currentUser.email.Equals(addUser.email)).
                       FirstOrDefault();
            if (userList == null)
            {
                dbContext.Users.Add(addUser);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(UserModel UserToDeleting)
        {
            
            var deleteUser = UserConverting.ConvertToDAL(UserToDeleting);

            var userList =
                       dbContext.Users.Where
                       (currentUser => currentUser.email.Equals(deleteUser.email)).
                       FirstOrDefault();
            if (userList != null)
            {
                dbContext.Users.Remove(deleteUser);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(UserModel UserToLogin)
        {
          
            var loginUser = UserConverting.ConvertToDAL(UserToLogin);
            var userList =
                      dbContext.Users.Where
                      (currentUser => currentUser.email.Equals(loginUser.email) 
                          &&
                       currentUser.userPassword.Equals(loginUser.userPassword)   
                          ).FirstOrDefault();
            if (userList != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO Reading USers method
        public List<UserModel> Read()
        {
            
            var userList = new List<UserModel>();

            foreach (var currentUser in dbContext.Users)
            {
                userList.Add(UserConverting.ConvertToModel(currentUser));
            }

            return userList;
        }
    }
}