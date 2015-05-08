using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Model;
using Twitter.DAL;
using Twitter.CRUD.Convertor;
using Twitter.CRUD.CRUD;
using Twitter.CRUD;

namespace Twitter.BL
{
    public class TweetBL
    {
        public List<TweetModel> SelectTweets(int idUser)
        {
            TweetCRUD readingTweets = new TweetCRUD();

            return readingTweets.Read(idUser);
        }

        public bool Message(TweetModel CurrentTweet, int idUser)
        {
            TweetCRUD AddingTweet = new TweetCRUD();
            if (AddingTweet.AddTweet(CurrentTweet, idUser))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTweet(int idTweet)
        {
            TweetCRUD TweetCrud = new TweetCRUD();
            return TweetCrud.DeleteTweet(idTweet);

        }

        public TweetModel EditTweet(int idTweet)
        {
            TweetCRUD TweetCrud = new TweetCRUD();
            TweetModel editingCurrentTweet = new TweetModel();
            editingCurrentTweet = TweetCrud.GetTweetById(idTweet);
            if (editingCurrentTweet != null)
            {
                return editingCurrentTweet;
            }
            else
            {
                return null;
            }

        }

        public bool EditTweet(TweetModel currentTweet)
            
        {
            TweetCRUD TweetCrud = new TweetCRUD();
            return TweetCrud.ChangeTweet(currentTweet, currentTweet.IdUser);

        }


    }
}
