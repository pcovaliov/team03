using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL
{
    public class UserDAL : IUserDAL
    {
        #region Private
        twitterEntities dbContext;
        #endregion

        public UserDAL() 
        {
            dbContext = new twitterEntities();
        }

        public bool AddUser(User UserToAdding)
        {
            var userList =
                       dbContext.Users.FirstOrDefault
                       (currentUser => currentUser.email.Equals(UserToAdding.email));
                       
            if (userList == null)
            {
                dbContext.Users.Add(UserToAdding);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int idUser)
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

        public List<User> ReadUsers()
        {
            var userList = new List<User>();

            foreach (var currentUser in dbContext.Users)
            {
                userList.Add(currentUser);
            }

            return userList;
        }

        public bool ChangeUser(User currentUser)
        {
            var userToChange =
                dbContext.Users.FirstOrDefault(user => user.id_user == currentUser.id_user);
            if (userToChange != null)
            {
                userToChange.first_name = currentUser.first_name;
                userToChange.last_name = currentUser.last_name;
                userToChange.email = currentUser.email;
                userToChange.avatar = currentUser.avatar;
                userToChange.userPassword = currentUser.userPassword;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public User GetUserById(int idUser)
        {
            var takedUser =
                dbContext.Users.FirstOrDefault(currentUser => currentUser.id_user.Equals(idUser));
            if (takedUser != null)
            {
                return takedUser;
            }
            return null;
        }
    }
}
