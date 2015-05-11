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
        #region Private
        UserModel myUserModel;
        User myUser;
        UserModel newUserModel;
        UserModel nullUser;
        UserModel nonExistUser;
        UserConvertor testConvertor;
        UserCRUD testCRUD;
        int getUser;
        int getNonExistingUser;
        UserModel userForChange;
        UserModel userForChangeWhatNotExists;
        #endregion

        public UserCRUD_Test()
        {
            myUserModel = new UserModel()
            {
                IdUser = 100,
                FirstName = "Scutari",
                LastName = "Mihai",
                Email = "scutari.mihai@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            testConvertor = new UserConvertor();
            newUserModel = new UserModel()
            {
                IdUser = 100,
                FirstName = "NewName",
                LastName = "NewLastname",
                Email = "NewMail@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            testCRUD = new UserCRUD();
            nonExistUser = new UserModel()
            {
                IdUser = -3,
                FirstName = "NonExist",
                LastName = "NonExist",
                Email = "NonExistMail@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"

            };
            myUser = new User()
            {
                first_name = "Scutari",
                last_name = "Mihai",
                email = "scutari.mihai@gmail.com",
                avatar = "1.jpg",
                userPassword = "endavatest",
            };
            nullUser = new UserModel()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Avatar = "",
                UserPassword = "",
                ConfirmPassword = "",
                IdUser = 0
            };
            getUser = 10;
            getNonExistingUser = -3;
            userForChange = new UserModel()
            {
                IdUser = 4,
                FirstName = "popodneac",
                LastName = "eugen",
                Email = "epopodneac@gmail.com",
                Avatar = "1.jpg",
                UserPassword = "endavatest",
                ConfirmPassword = "endavatest"
            };
            userForChangeWhatNotExists = new UserModel()
            {
                IdUser = -1,
                FirstName = "noName",
                LastName = "noLastaName",
                Email = "noMail@gmail.com",
                Avatar = "noavatar",
                UserPassword = "noPassword",
                ConfirmPassword = "noConfirm"
            };
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

            //act
            User currentUser = testConvertor.ConvertToDAL(myUserModel);

            //assert
            Assert.AreEqual("Twitter.DAL.User", currentUser.GetType().ToString());
        }

        [TestMethod]
        public void TryToConvertUserIntoUserModel_ShouldBeReturnUserModelType()
        {
            //arrange

            //act
            UserModel currentUser = testConvertor.ConvertToModel(myUser);

            //assert
            Assert.AreEqual("Twitter.Model.UserModel", currentUser.GetType().ToString());
        }

        [TestMethod]
        public void TryToInsertExistingUser_ShouldBeReturnBoolValueFalse()
        {
            //arrange
            var testCRUD = new UserCRUD();

            //act
            bool control = testCRUD.AddUser(myUserModel);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void TryToInsertNewUser_ShouldBeReturnBoolValueTrue()
        {
            //arrange

            //act
            bool control = testCRUD.AddUser(newUserModel);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void TryToInsertNullUser_ShouldBeReturnBoolValueFalse()
        {
            //arrange

            //act
            bool control = testCRUD.AddUser(nullUser);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void TryToDeleteExistingUser_ShouldBeReturnBoolValueTrue()
        {
            //arrange
            int idUser = 24;

            //act
            bool control = testCRUD.Delete(idUser);

            //assert
            Assert.AreEqual(true, control);
        }

        [TestMethod]
        public void TryToDeleteNonExistingUser_ShouldBeReturnBoolValueFalse()
        {
            //arrange
            int idUser = -3;
            //act
            bool control = testCRUD.Delete(idUser);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void TryToReadAllUsers_ShouldBeReturnUserModelList()
        {
            //arrange

            //act
            var expectedType = testCRUD.Read();

            //assert
            Assert.AreEqual("System.Collections.Generic.List`1[Twitter.Model.UserModel]", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void TryToGetUserById_ShouldBeReturnUserModelObject()
        {
            //arrange

            //act
            var expectedType = testCRUD.GetUserById(getUser);

            //assert
            Assert.AreEqual("Twitter.Model.UserModel", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void TryToGetNonExistingUserById_ShouldBeReturFalseValue()
        {
            //arrange

            //act
            var expectedType = testCRUD.GetUserById(getUser);

            //assert
            Assert.AreEqual(false, expectedType.GetType().IsValueType);
        }

        [TestMethod]
        public void TryToChangeExistingUser_ShouldBeReturTrueValue()
        {
            //arrange

            //act
            var expectedValue = testCRUD.ChangeUser(userForChange);

            //assert
            Assert.AreEqual(true, expectedValue);
        }

        [TestMethod]
        public void TryToChangeNonExistingUser_ShouldBeReturFalseValue()
        {
            //arrange

            //act
            var expectedValue = testCRUD.ChangeUser(userForChangeWhatNotExists);

            //assert
            Assert.AreEqual(false, expectedValue);
        }
    }
}
