using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Operations.Convertor
{
    class FollowConvertor
    {
        public Follow ConvertToDAL(FollowModel convertedFollow)
        {
            Follow currentFollow = new Follow();
            currentFollow.id_followed_user = convertedFollow.IdFollowedUser;
            currentFollow.id_subscriber = convertedFollow.IdSubscriber;
            return currentFollow;
        }

        public FollowModel ConvertToModel(Follow ConvertedFollow)
        {
            FollowModel currentFollow = new FollowModel();
            currentFollow.IdSubscriber = ConvertedFollow.id_subscriber;
            currentFollow.IdFollowedUser = ConvertedFollow.id_followed_user;
            return currentFollow;
        }
    }
}
