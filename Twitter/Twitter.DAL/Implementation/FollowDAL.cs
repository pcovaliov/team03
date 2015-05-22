using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DAL.Interfaces;

namespace Twitter.DAL.Implementation
{
    public class FollowDAL : IFollowDAL
    {
        #region Private
        twitterEntities dbContext;
        #endregion

        public FollowDAL() 
        {
            dbContext = new twitterEntities();
        }

        public bool AddFollow(Follow newFollow)
        {
            if (newFollow != null)
            {
                dbContext.Follows.Add(newFollow);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteFollow(int idSubscriber, int idFollowedUser)
        {
            var followToDelete =
                dbContext.Follows.FirstOrDefault(currentFollow => currentFollow.id_subscriber.Equals(idSubscriber) && currentFollow.id_followed_user.Equals(idFollowedUser));

            if (followToDelete != null)
            {
                dbContext.Follows.Remove(followToDelete);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Follow> ReadFollows() 
        {
            var followList = new List<Follow>();

            foreach (var currentFollow in dbContext.Follows)
            {
                followList.Add(currentFollow);
            }

            return followList;
        }
    }
}
