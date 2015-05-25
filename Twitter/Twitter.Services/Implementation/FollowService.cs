using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Services.Interfaces;
using Twitter.Models;
using Twitter.DAL.Interfaces;
using Twitter.Convert;

namespace Twitter.Services.Implementation
{
    public class FollowService : IFollowService
    {
        #region Private
        public IFollowDAL FollowDal { get; set; }
        #endregion

        public bool Subscribe(int Subscriber, int FollowedUser)
        {
            return FollowDal.AddFollow(FollowConvertor.ConvertToDAL(Subscriber,FollowedUser));
        }

        public bool UnSubscribe(int Subscriber, int FollowedUser)
        {
            return FollowDal.DeleteFollow(Subscriber, FollowedUser);
        }

        public List<FollowModel> GetSubscribers(int idUser)
        {
            var allSubscribers = new List<FollowModel>();
            foreach (var currentFollow in FollowDal.ReadFollows(idUser))
            {
                allSubscribers.Add(FollowConvertor.ConvertToModel(currentFollow));
            }
            return allSubscribers;
        }
    }
}
