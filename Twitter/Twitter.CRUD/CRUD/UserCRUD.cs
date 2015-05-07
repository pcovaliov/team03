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

        public bool AddUser(UserModel UserToAdding)
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

        //TODO Reading USers method
        public List<UserModel> Read()
        {
            twitterEntities dbContext = new twitterEntities();
            UserConvertor UserConverting = new UserConvertor();
            var userList = new List<UserModel>();

            foreach (var currentUser in dbContext.Users)
            {
                userList.Add(UserConverting.ConvertToModel(currentUser));
            }

            return userList;
        }
    }
}
