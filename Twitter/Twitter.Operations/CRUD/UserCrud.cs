using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Operations.Convertor;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Operations.CRUD
{
    class UserCrud
    {
        public UserConvertor ConvertingUser = new UserConvertor();
        User myUser = new User();
        UserModel myUserModel = new UserModel();
    }
}
