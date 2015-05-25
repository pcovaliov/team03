using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Services.Interfaces
{
    public interface IFollowService
    {
        bool Subscribe(int Subscriber, int FollowedUser);
        bool UnSubscribe(int Subscriber, int FollowedUser);
        List<FollowModel> GetSubscribers(int idUser);
    }
}
