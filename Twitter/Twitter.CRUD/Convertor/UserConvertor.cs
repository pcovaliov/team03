using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Model;

namespace Twitter.CRUD.Convertor
{
    public class UserConvertor
    {
        public User ConvertToDAL(UserModel convertedUser)
        {
            User currentUser = new User();
            currentUser.first_name = convertedUser.FirstName;
            currentUser.last_name = convertedUser.LastName;
            currentUser.email = convertedUser.Email;
            currentUser.avatar = convertedUser.Avatar;
            currentUser.userPassword = convertedUser.UserPassword;

            return currentUser;
        }

        public UserModel ConvertToModel(User ConvertedUser)
        {
            UserModel currentUser = new UserModel();
            currentUser.FirstName = ConvertedUser.first_name;
            currentUser.LastName = ConvertedUser.last_name;
            currentUser.Email = ConvertedUser.email;
            currentUser.Avatar = ConvertedUser.avatar;
            currentUser.UserPassword = ConvertedUser.userPassword;
            currentUser.IdUser = ConvertedUser.id_user;

            return currentUser;
        }
    }
}
