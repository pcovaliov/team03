using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Convert
{
    public class FollowConvertor
    {
        public static Follow ConvertToDAL(FollowModel followToConvert)
        {
            Follow newFollow = new Follow();
            newFollow.id_followed_user = followToConvert.idFollowedUser;
            newFollow.id_subscriber = followToConvert.idSubscriber;

            return newFollow;
        }

        public static FollowModel ConvertToModel(Follow followToConvert)
        {
            FollowModel newFollowModel = new FollowModel();
            newFollowModel.idSubscriber = followToConvert.id_subscriber;
            newFollowModel.idFollowedUser = followToConvert.id_followed_user;
            newFollowModel.idFollow = followToConvert.id_follow;

            return newFollowModel;
        }
    }
}
