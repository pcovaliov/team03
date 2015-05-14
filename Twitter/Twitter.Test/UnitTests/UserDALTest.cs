using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.DAL;


namespace Twitter.Test.UnitTests
{
    [TestClass]
    public class UserDALTest
    {
        #region DecalrationOfVariables
        User testUser;
        User changeTestUser;
        User changeNonExistingUser;
        public IUserDAL UserDal { get; set; }
        #endregion

        public UserDALTest()
        {
            UserDal = new UserDAL();

            testUser = new User() 
            {
                first_name = "TestName",
                last_name = "TestLast",
                email = "test.user@gmail.com",
                avatar = "test.jpg",
                userPassword = "endavatest",
            };

            changeTestUser = new User()
            {
                first_name = "TestFirstName",
                last_name = "TestLastName",
                email = "Test.user@gmail.com",
                avatar = "Test.jpg",
                userPassword = "endavatest",
            };

            changeNonExistingUser = new User()
            {
                id_user = -3,
                first_name = "NoName",
                last_name = "TNoLastName",
                email = "TNo@gmail.com",
                avatar = "No.jpg",
                userPassword = "Nopassword",
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
        public void AddUser_AddNewUserInDatabase_True()
        {
            //arrange

            //act
            bool control = UserDal.AddUser(testUser);

            //assert
            Assert.AreEqual(true, control);
        }

        [TestMethod]
        public void ChangeUser_ChangeExistingUser_True()
        {
            //arrange
            var takeLastUser = UserDal.ReadUsers().ToArray();
            int idUser = takeLastUser[takeLastUser.Length - 1].id_user;
            changeTestUser.id_user = idUser;
            //act
            var expectedValue = UserDal.ChangeUser(changeTestUser);

            //assert
            Assert.AreEqual(true, expectedValue);
        }

        [TestMethod]
        public void DeleteUser_DeleteUserFromDatabase_True()
        {
            //arrange
            var takeLastUser = UserDal.ReadUsers().ToArray();
            int idUser = takeLastUser[takeLastUser.Length - 1].id_user;
            //act
            bool control = UserDal.DeleteUser(idUser);

            //assert
            Assert.AreEqual(true, control);
        }

        [TestMethod]
        public void DeleteUser_DeleteNonExistingUser_False()
        {
            //arrange
            int idUser = -3;
            //act
            bool control = UserDal.DeleteUser(idUser);

            //assert
            Assert.AreEqual(false, control);
        }

        [TestMethod]
        public void ReadUsers_SelectAllUsersFromDatabase_ListOfUserEntity()
        {
            //arrange

            //act
            var expectedType = UserDal.ReadUsers();

            //assert
            Assert.AreEqual("System.Collections.Generic.List`1[Twitter.DAL.User]", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void GetUserById_GetExistingUserById_UserEntity()
        {
            //arrange

            //act
            var expectedType = UserDal.GetUserById(1);

            //assert
            Assert.AreEqual("Twitter.DAL.User", expectedType.GetType().ToString());
        }

        [TestMethod]
        public void GetUserById_GetNonExistingUserById_Null()
        {
            //arrange

            //act
            var expectedType = UserDal.GetUserById(-3);

            //assert
            Assert.AreEqual(null, expectedType);
        }

        [TestMethod]
        public void GetUserById_ChangeNonExistingUser_False()
        {
            //arrange

            //act
            var expectedValue = UserDal.ChangeUser(changeNonExistingUser);

            //assert
            Assert.AreEqual(false, expectedValue);
        }
    }
}
