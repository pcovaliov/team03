using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Services
{
    public interface ITweetService
    {
        List<TweetModel> SelectTweets(int idUser);
        bool Message(TweetModel CurrentTweet, int idUser);
        bool DeleteTweet(int idTweet);
        TweetModel GetTweet(int idTweet);
        bool EditTweet(TweetModel currentTweet, int idUser);
    }
}
