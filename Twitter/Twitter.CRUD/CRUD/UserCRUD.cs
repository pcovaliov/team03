using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Model;
using Twitter.CRUD.Convertor;

namespace Twitter.CRUD.CRUD
{
    public class UserCRUD
    {
        #region Private
        twitterEntities dbContext;
        UserConvertor UserConverting;
        #endregion

        public  UserCRUD() 
        {
            dbContext = new twitterEntities();
            UserConverting = new UserConvertor();
        }

        public bool AddUser(UserModel UserToAdding)
        {
            var addUser = UserConverting.ConvertToDAL(UserToAdding);
            var userList =
                       dbContext.Users.FirstOrDefault
                       (currentUser => currentUser.email == addUser.email);
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
                       dbContext.Users.FirstOrDefault
                       (currentUser => currentUser.email == deleteUser.email);
            if (userList != null)

            {
                dbContext.Users.Remove(userList);
                dbContext.SaveChanges();
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
