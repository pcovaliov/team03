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


        public bool Add(UserModel UserToAdding)
        {
            twitterEntities dbContext = new twitterEntities();
            UserConvertor UserConverting = new UserConvertor();
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
            twitterEntities dbContext = new twitterEntities();
            UserConvertor UserConverting = new UserConvertor();
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
            twitterEntities dbContext = new twitterEntities();
            UserConvertor UserConverting = new UserConvertor();
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
        //public List<UserModel> Read(User UserToReading) 
        //{ 
            
        //}
    }
}