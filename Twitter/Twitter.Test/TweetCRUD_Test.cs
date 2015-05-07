using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Model;
using Twitter.CRUD.CRUD;
using Twitter.CRUD;
using Twitter.CRUD.Convertor;
using Twitter.DAL;

namespace Twitter.Test
{
    /// <summary>
    /// Summary description for TweetCRUD_Test
    /// </summary>
    [TestClass]
    public class TweetCRUD_Test
    {
        public TweetCRUD_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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
        public void TryToConvertTweetModelIntoTweet_ShouldBeReturnTweetType()
        {
            //arrange
            var myTweet = new TweetModel()
            {
                Descripton = "test tweet",
            };
            var testCRUD = new TweetConvertor();

            //act
            var currentTweet = testCRUD.ConvertTweetToDAL(myTweet);

            //assert
            Assert.AreEqual("Twitter.DAL.Tweet", currentTweet.GetType().ToString());
        }

        [TestMethod]
        public void TryToConvertTweetIntoTweetModel_ShouldBeReturnTweetModelType()
        {
            //arrange
            var myTweet = new Tweet()
            {
                descripton = "test tweet",
                created_on = DateTime.Now.ToString(),
                id_tweet = 20,
                id_user = 19
            };
            var testCRUD = new TweetConvertor();

            //act
            var currentTweet = testCRUD.ConvertTweetToModel(myTweet);

            //assert
            Assert.AreEqual("Twitter.Model.TweetModel", currentTweet.GetType().ToString());
        }

        [TestMethod]
        public void TryToAddNewTweet_ShouldBeReturnTrueValue()
        {
            //arrange
            var myTweet = new TweetModel()
            {
                Descripton = "test tweet",
            };
            var testCRUD = new TweetCRUD();

            //act
            var currentTweet = testCRUD.AddTweet(myTweet);

            //assert
            Assert.AreEqual(true, currentTweet);
        }

        [TestMethod]
        public void TryToDeleteExistingTweet_ShouldBeReturnTrueValue()
        {
            //arrange
            var myTweet = new TweetModel()
            {
                Descripton = "fsgsdgasdfasdf9348759646547568",
                IdTweet = 10,
                IdUser = 1,
                CreatedOn = "2015-05-07 10:18:47"
            };
            var testCRUD = new TweetCRUD();

            //act
            var currentTweet = testCRUD.Delete(myTweet);

            //assert
            Assert.AreEqual(true, currentTweet);
        }

        [TestMethod]
        public void TryToDeleteNonExistingTweet_ShouldBeReturnFalseValue()
        {
            //arrange
            var myTweet = new TweetModel()
            {
                Descripton = "vasea roma jenea",
                IdTweet = 10,
                IdUser = -3,
                CreatedOn = "2015-05-07 10:18:47"
            };
            var testCRUD = new TweetCRUD();

            //act
            var currentTweet = testCRUD.Delete(myTweet);

            //assert
            Assert.AreEqual(false, currentTweet);
        }

        [TestMethod]
        public void TryToReadAllTweets_ShouldBeReturnTweetModelList()
        {
            //arrange
            var testCRUD = new TweetCRUD();

            //act
            var expectedType = testCRUD.Read();

            //assert
            Assert.AreEqual("System.Collections.Generic.List`1[Twitter.Model.TweetModel]", expectedType.GetType().ToString());
        }
    }
}
