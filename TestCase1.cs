using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AnswerDigital
{
    [TestFixture]
    public class TestCase1
    {
		/// <summary>
        /// Scenario 1
        /// </summary>
		[Test]
        public void Login_CorrectUsernameWrongPassword_Validation()
        {
            // Arrange:
            var driver = new ChromeDriver();
            driver.Url = "http://the-internet.herokuapp.com/login";
            driver.Manage().Window.Maximize();
            var usernameTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input"));
            var passwordTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input"));
            var loginField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/button/i"));

            // Act:
            usernameTextField.SendKeys("tomsmith");
            passwordTextField.SendKeys("incorrectPassword!");
            loginField.Click();

            // Assert:
            var actual = driver.FindElement(By.Id("flash")).Text;
            var expected = "Your password is invalid!\r\n×";
            Assert.AreEqual(expected, actual);

            // Clean up:
            driver.Close();
        }

    


        /// <summary>
        /// Scenario 2
        /// </summary>
        [Test]
        public void Login_WrongUsernameCorrectPassword_Validation()
        {
            // Arrange:
            var driver = new ChromeDriver();
            driver.Url = "http://the-internet.herokuapp.com/login";
            driver.Manage().Window.Maximize();
            var usernameTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input"));
            var passwordTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input"));
            var loginField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/button/i"));

            // Act:
            usernameTextField.SendKeys("incorrectUsername");
            passwordTextField.SendKeys("SuperSecretPassword!");
            loginField.Click();

            // Assert:
            var actual = driver.FindElement(By.Id("flash")).Text;
            var expected = "Your username is invalid!\r\n×";
            Assert.AreEqual(expected, actual);

            // Clean up:
            driver.Close();
        }




        /// <summary>
        /// Scenario 3
        /// </summary>
        [Test]
        public void Login_CorrectUsernameCorrectPassword_NoValidation()
        {
            // Arrange:
            var driver = new ChromeDriver();
            driver.Url = "http://the-internet.herokuapp.com/login";
            driver.Manage().Window.Maximize();
            var usernameTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/input"));
            var passwordTextField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/input"));
            var loginField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/button/i"));
            
            // Act:
            usernameTextField.SendKeys("tomsmith");
            passwordTextField.SendKeys("SuperSecretPassword!");
            loginField.Click();
            var logoutField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/a/i"));
            logoutField.Click();

            // Clean up:
            driver.Close();
        }
    }
}