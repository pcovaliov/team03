using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Convert;
using Twitter.DAL;
using Twitter.Models;

namespace Twitter.Test.UnitTests
{
    [TestClass]
    public class ConvertorTest
    {
        #region Declarations
        Tweet testTweet;
        TweetModel testTweetModel;
        User testUser;
        UserModel testUserModel;
        #endregion

        public ConvertorTest()
        {
            testTweet = new Tweet()
            {
                descripton = "New Tweet",
                created_on = DateTime.Now,
                id_user = 1,
            };

            testTweetModel = new TweetModel() 
            {
                Descripton = "New Tweet",
                CreatedOn = DateTime.Now,
            };

            testUser = new User()
            {
                first_name = "TestName",
                last_name = "TestLastName",
                email = "test.user@gmail.com",
                avatar = "test.jpg",
                userPassword = "endavatest",
            };

            testUserModel = new UserModel() 
            { 
                FirstName = "TestName",
                LastName = "TestLastName",
                Email = "Test.user@gmail.com",
                Avatar = "test.jpg",
                UserPassword = "endavatest",
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
        public void ConvertToModel_ConvertUserEntityToUserModel_UserModel()
        {
            //arrange
            //act
            var expectedType = UserConvertor.ConvertToModel(testUser);
            //asseert
            Assert.AreEqual("Twitter.Models.UserModel", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void ConvertToModel_ConvertTweetEntityToTweetModel_TweetModel()
        {
            //arrange
            //act
            var expectedType = TweetConvertor.ConvertTweetToModel(testTweet);
            //asseert
            Assert.AreEqual("Twitter.Models.TweetModel", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void ConvertToDAL_ConvertUserModelToUserEntity_UserEntity()
        {
            //arrange
            //act
            var expectedType = UserConvertor.ConvertToDAL(testUserModel);
            //asseert
            Assert.AreEqual("Twitter.DAL.User", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void ConvertToDAL_ConvertTweetModelToTweetEntity_TweetEntity()
        {
            //arrange
            //act
            var expectedType = TweetConvertor.ConvertTweetToDAL(testTweetModel, 1);
            //asseert
            Assert.AreEqual("Twitter.DAL.Tweet", expectedType.GetType().ToString());
        }
    }
}
