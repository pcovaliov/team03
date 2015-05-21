using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Models;
using Twitter.Services;

namespace Twitter.Test.UnitTests
{
    [TestClass]
    public class UserServiceTest
    {
        #region Declarations
        UserModel testUser;
        public IUserService UserService{get; set;}
        #endregion

        public UserServiceTest()
        {
            UserService = new UserService();
            testUser = new UserModel()
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

        //[TestMethod]
        //public void Register_RegisterOfNewValidUser_True()
        //{
        //    //arrange
        //    //act
        //    var expectedValue = UserService.Register(testUser);
        //    //assert
        //    Assert.AreEqual(true, expectedValue);
        //}
    }
}
