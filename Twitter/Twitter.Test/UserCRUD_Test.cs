using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Model;
using Twitter.CRUD.CRUD;
using Twitter.CRUD.Convertor;
using Twitter.DAL;

namespace Twitter.Test
{
    [TestClass]
    public class UserCRUD_Test
    {
        public UserCRUD_Test()
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
        public void TryToConvertUserModelIntoUser_ShouldBeReturnUserType()
        {
            //arrange
            var myUser = new UserModel()
            {
                FirstName = "Scutari",
                LastName = "Mihai",
                Email = "scutari.mihai@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            var testCRUD = new UserConvertor();

            //act
            User currentUser = testCRUD.ConvertToDAL(myUser);

            //assert
            Assert.AreEqual("Twitter.DAL.User", currentUser.GetType().ToString());
        }

        [TestMethod]
        public void TryToConvertUserIntoUserModel_ShouldBeReturnUserModelType()
        {
            //arrange
            var myUser = new User()
            {
                first_name = "Scutari",
                last_name = "Mihai",
                email = "scutari.mihai@gmail.com",
                avatar = "1.jpg",
                userPassword = "endavatest"
            };
            var testCRUD = new UserConvertor();

            //act
            UserModel currentUser = testCRUD.ConvertToModel(myUser);

            //assert
            Assert.AreEqual("Twitter.Model.UserModel", currentUser.GetType().ToString());
        }

        [TestMethod]
        public void TryToInsertExistingUser_ShouldBeReturnBoolValueFalse()
        {
            //arrange
            var myUser = new UserModel()
            {
                FirstName = "Scutari",
                LastName = "Mihai",
                Email = "scutari.mihai@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            var testCRUD = new UserCRUD();

            //act
            bool control = testCRUD.AddUser(myUser);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void TryToInsertNewUser_ShouldBeReturnBoolValueTrue()
        {
            //arrange
            var myUser = new UserModel()
            {
                FirstName = "NewName",
                LastName = "NewLastname",
                Email = "NewMail@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            var testCRUD = new UserCRUD();

            //act
            bool control = testCRUD.AddUser(myUser);

            //assert
            Assert.AreEqual(true, control);
        }

        //[TestMethod]
        //public void TryToInsertUserEntity_ShouldBeReturnBoolValueFalse()
        //{
        //    //arrange
        //    var myUser = new User()
        //    {
        //        first_name = "Scutari",
        //        last_name = "Mihai",
        //        email = "scutari.mihai@gmail.com",
        //        avatar = "1.jpg",
        //        userPassword = "endavatest",
        //    };
        //    var testCRUD = new UserCRUD();

        //    //act
        //    bool control = testCRUD.AddUser(myUser);
        //    //assert
        //    Assert.AreEqual(false, control);
        //}

        [TestMethod]
        public void TryToReadAllUsers_ShouldBeReturnUserModelList()
        {
            //arrange
            var testCRUD = new UserCRUD();

            //act
            var expectedType = testCRUD.Read();

            //assert
            Assert.AreEqual("System.Collections.Generic.List`1[Twitter.Model.UserModel]", expectedType.GetType().ToString());
        }
    }
}
