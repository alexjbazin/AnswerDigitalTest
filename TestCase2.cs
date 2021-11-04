using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AnswerDigital
{
    [TestFixture]
    public class TestCase2
    {
        [Test]
        public void Scroll_ScrollToBottomTwiceAndBackUp_HeadingExists()
		{
            // Arrange:
            var driver = new ChromeDriver();
            driver.Url = "http://the-internet.herokuapp.com/infinite_scroll";
            driver.Manage().Window.Maximize();
            var scrollDownScript = "window.scrollTo(0, document.body.scrollHeight);";
            var scrollDownUp = "document.documentElement.scrollTop = 0;";

            // Act:
            driver.ExecuteScript(scrollDownScript);
            driver.ExecuteScript(scrollDownScript);
            driver.ExecuteScript(scrollDownUp);

            // Assert:
            var expected = "Infinite Scroll";
            var actual = driver.FindElement(By.XPath("/html/body/div[2]/div/div/h3")).Text;
            Assert.AreEqual(expected, actual);

            // Clean up:
            driver.Close();
        }
    }
}