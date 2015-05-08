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
       public twitterEntities dbContext = new twitterEntities();
        public bool AddUser(UserModel UserToAdding)
        {
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

        public UserModel GetUserById(int idUser)
        {
            UserModel editedUser = new UserModel();
            var userEdit =
                dbContext.Users.Where(currentUser => currentUser.id_user.Equals(idUser)).FirstOrDefault();
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

        //TODO Reading USers method
        public List<UserModel> Read()
        {          
            UserConvertor userConverting = new UserConvertor();
            var userList = new List<UserModel>();

            foreach (var currentUser in dbContext.Users)
            {
                userList.Add(userConverting.ConvertToModel(currentUser));
            }

            return userList;
        }

        public bool ChangeUser(UserModel currentUser) 
        { 
            UserConvertor changeUser = new UserConvertor();
            var currentUserToChange = changeUser.ConvertToDAL(currentUser);
            var userToChange =
                dbContext.Users.FirstOrDefault(user => user.id_user == currentUserToChange.id_user);
            userToChange.first_name = currentUserToChange.first_name;
                userToChange.last_name = currentUserToChange.last_name;
                userToChange.email = currentUserToChange.email;
                userToChange.avatar = currentUserToChange.avatar;
                userToChange.userPassword = currentUserToChange.userPassword;        
            dbContext.SaveChanges();
            return true;
        }
    }
}
