using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL
{
    public interface IUserDAL
    {
        bool AddUser(User UserToAdding);
        bool DeleteUser(int IdUser);
        User GetUserById(int IdUser);
        List<User> ReadUsers();
        bool ChangeUser(User currentUser);
    }
}
