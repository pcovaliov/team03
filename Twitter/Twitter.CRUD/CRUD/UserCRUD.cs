using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Model;
using Twitter.CRUD.Convertor;
using System.Data.Entity;

namespace Twitter.CRUD.CRUD
{
    public class UserCRUD
    {
        #region Private
        twitterEntities dbContext;
        UserConvertor UserConverting;
        #endregion

        public UserCRUD()
        {
            dbContext = new twitterEntities();
            UserConverting = new UserConvertor();
        }
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
        public bool Delete(int idUser)
        {
            var userDeleted =
            dbContext.Users.FirstOrDefault(currentUser => currentUser.id_user.Equals(idUser));
            if (userDeleted != null)
            {
                dbContext.Users.Remove(userDeleted);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public UserModel GetUserById(int idUser)
        {
            UserModel editedUser = new UserModel();
            var userEdit =
                dbContext.Users.FirstOrDefault(currentUser => currentUser.id_user.Equals(idUser));
            if (userEdit != null)
            {
                editedUser.IdUser = userEdit.id_user;
                editedUser.FirstName = userEdit.first_name;
                editedUser.LastName = userEdit.last_name;
                editedUser.Email = userEdit.email;
                editedUser.Avatar = userEdit.avatar;
                editedUser.UserPassword = userEdit.userPassword;
                return editedUser;
            }
            return null;
        }

        public List<UserModel> Read()
        {
            var userList = new List<UserModel>();

            foreach (var currentUser in dbContext.Users)
            {
                userList.Add(UserConverting.ConvertToModel(currentUser));
            }

            return userList;
        }

        public bool ChangeUser(UserModel currentUser)
        {
            var currentUserToChange = UserConverting.ConvertToDAL(currentUser);
            var userToChange =
                dbContext.Users.FirstOrDefault(user => user.id_user == currentUserToChange.id_user);
            if (userToChange != null)
            {
                userToChange.first_name = currentUserToChange.first_name;
                userToChange.last_name = currentUserToChange.last_name;
                userToChange.email = currentUserToChange.email;
                userToChange.avatar = currentUserToChange.avatar;
                userToChange.userPassword = currentUserToChange.userPassword;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
