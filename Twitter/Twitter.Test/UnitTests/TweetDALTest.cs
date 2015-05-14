using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.DAL;

namespace Twitter.Test.UnitTests
{
    [TestClass]
    public class TweetDALTest
    {
        #region DecalrationOfVariables
        Tweet testTweet;
        Tweet changeTestTweet;
        Tweet changeNonExistingTweet;
        public ITweetDAL TweetDal {get; set;}
        #endregion

        public TweetDALTest()
        {
            TweetDal = new TweetDAL();
            testTweet = new Tweet() 
            { 
                descripton = "New Tweet",
                created_on = DateTime.Now,
                id_user = 1,
            };
            changeTestTweet = new Tweet()
            {
                descripton = "New Tweet Changed",
                created_on = DateTime.Now,
                id_user = 1,
            };

            changeNonExistingTweet = new Tweet() 
            { 
                descripton = "does not exist",
                created_on = DateTime.Now,
                id_tweet = -1,
                id_user = 1,
            };
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddTweet_AddNewTweet_True()
        {
            //arrange

            //act
            var currentTweet = TweetDal.AddTweet(testTweet);

            //assert
            Assert.AreEqual(true, currentTweet);
        }

        [TestMethod]
        public void ChangeTweet_AddExistingTweet_True()
        {
            //arrange
            var tweets = TweetDal.ReadTweets(1).ToArray();
            changeTestTweet.id_tweet = tweets[tweets.Length - 1].id_tweet;
            //act
            var currentTweet = TweetDal.ChangeTweet(changeTestTweet);

            //assert
            Assert.AreEqual(true, currentTweet);
        }

        [TestMethod]
        public void DeleteTweet_DeleteExistingTweet_True()
        {
            //arrange
            var tweets = TweetDal.ReadTweets(1).ToArray();
            int idTweet = tweets[tweets.Length - 1].id_tweet;
            //act
            var currentTweet = TweetDal.DeleteTweet(idTweet);

            //assert
            Assert.AreEqual(true, currentTweet);
        }

        [TestMethod]
        public void DeleteTweet_DeleteNonExistingTweet_False()
        {
            //arrange
            //act
            var currentTweet = TweetDal.DeleteTweet(-1);

            //assert
            Assert.AreEqual(false, currentTweet);
        }

        [TestMethod]
        public void ChangeTweet_AddNonExistingTweet_False()
        {
            //arrange

            //act
            var currentTweet = TweetDal.ChangeTweet(changeNonExistingTweet);

            //assert
            Assert.AreEqual(false, currentTweet);
        }

        [TestMethod]
        public void GetTweetById_GetExistingTweetById_TweetEntity()
        {
            //arrange

            //act
            var currentTweet = TweetDal.GetTweetById(1);

            //assert
            Assert.AreEqual("Twitter.DAL.Tweet", currentTweet.GetType().ToString());
        }

        [TestMethod]
        public void GetTweetById_GetNonExistingTweetById_Null()
        {
            //arrange

            //act
            var currentTweet = TweetDal.GetTweetById(-1);

            //assert
            Assert.AreEqual(null, currentTweet);
        }

        [TestMethod]
        public void ReadTweets_ReadAllTweetsFromDatabase_ListOfTweetEnetity()
        {
            //arrange

            //act
            var currentTweet = TweetDal.ReadTweets(1);

            //assert
            Assert.AreEqual("System.Collections.Generic.List`1[Twitter.DAL.Tweet]", currentTweet.GetType().ToString());
        }
    }
}
