using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
namespace Twitter.Test
{
    [TestClass]
    public class UserAutomationTest
    {
        #region Declaration
        IWebDriver driver;
        IWebElement element;
        string FirstName;
        string LastName;
        string Email;
        string Password;
        string ConfirmPassword;
        #endregion
        public UserAutomationTest()
        {
            #region Initialization
            driver = new ChromeDriver();
            FirstName = "Evghenii";
            LastName = "Popodneac";
            Password = ConfirmPassword = "endavatest";
            Email = "evpopodneac@gmail.com";
            #endregion
        }
        public bool Login()
        {
            driver.Navigate().GoToUrl("http://localhost:61785/User/Login");
            element = driver.FindElement(By.Name("Email"));
            element.SendKeys(Email.ToString());
            element = driver.FindElement(By.Name("UserPassword"));
            element.SendKeys(Password.ToString());
            driver.FindElement(By.Name("singlebutton")).Click();
            if (driver.Title == "DisplayUsers")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public void CompletingRegistrationForm_RedirectedToLoginForm()
        {
            //Arange
            driver.Navigate().GoToUrl("http://localhost:61785/User/Register");
            element = driver.FindElement(By.Name("FirstName"));
            element.SendKeys(FirstName);
            element = driver.FindElement(By.Name("LastName"));
            element.SendKeys(LastName);
            element = driver.FindElement(By.Name("Email"));
            element.SendKeys(Email.ToString());
            element = driver.FindElement(By.Name("UserPassword"));
            element.SendKeys(Password.ToString());
            element = driver.FindElement(By.Name("ConfirmPassword"));
            element.SendKeys(ConfirmPassword.ToString());
            //Act
            driver.FindElement(By.Name("singlebutton")).Click();
            //Assert
            Assert.AreEqual("Login", driver.Title);
        }

        [TestMethod]
        public void SearchRegistredUser()
        {
            //Act
            if (Login())
            {
                var email = driver.FindElement(By.XPath("//tr/td[contains(text(),'evpopodneac@gmail.com')]"));
                Assert.AreEqual(Email, email.Text);
            }
            driver.FindElement(By.XPath("//tr[2]/td[4]/a[2]")).Click();

        }
    }
}

