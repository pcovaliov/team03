using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Services
{
    public interface IUserService
    {
        bool Register(UserModel CurrentUser);
        int Login(UserModel UserToLogin);
        List<UserModel> SelectUsers();
        UserModel GetUser(int idUser);
        bool EditUser(UserModel currentUser);
        bool DeleteUser(int idUser);
    }
}

