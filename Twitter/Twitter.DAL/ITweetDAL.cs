using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DAL
{
    public interface ITweetDAL
    {
        bool AddTweet(Tweet TweetToAdding);
        List<Tweet> ReadTweets(int idUser);
        bool DeleteTweet(int idTweet);
        Tweet GetTweetById(int idTweet);
        bool ChangeTweet(Tweet currentTweet);
    }
}
