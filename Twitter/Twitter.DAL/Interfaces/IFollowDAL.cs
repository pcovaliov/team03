using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL.Interfaces
{
    public interface IFollowDAL
    {
        bool AddFollow(Follow newFollow);
        bool DeleteFollow(int idSubscriber, int idFollowedUser);
        List<Follow> ReadFollows();
    }
}
