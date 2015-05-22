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
            element.SendKeys("admin@endava.com");
            element = driver.FindElement(By.Name("UserPassword"));
            element.SendKeys("endavaAdmin");
            driver.FindElement(By.Name("submitbutton")).Click();
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
            driver.FindElement(By.Name("submitbutton")).Click();
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
            driver.FindElement(By.XPath("id('TableRow')/a[2]")).Click();

        }
        [TestMethod]
        public void AddingNewTweetAndDeleteTweet()
        {
            if (Login())
            {
                driver.FindElement(By.XPath("//ul/li[4]/a/span")).Click();
                element = driver.FindElement(By.Name("Descripton"));
                element.SendKeys("HELLO");
                driver.FindElement(By.Name("addbutton")).Click();
                var tweet = driver.FindElement(By.XPath("/html/body/div/div[2]/div/table/tbody/tr[2]/td[1][contains(text(),'HELLO')]"));
                Assert.AreEqual("HELLO", tweet.Text);
                driver.FindElement(By.XPath("/html/body/div/div[2]/div/table/tbody/tr[2]/td[3]/a[2]")).Click();
            }
        }
    }
}

