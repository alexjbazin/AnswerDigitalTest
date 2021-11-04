using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AnswerDigital
{
    [TestFixture]
    public class TestCase3
    {
        [Test]
        public void Scroll_ScrollToBottomTwiceAndBackUp_HeadingExists()
		{
            // Arrange:
            var driver = new ChromeDriver();
            driver.Url = "http://the-internet.herokuapp.com/key_presses";
            driver.Manage().Window.Maximize();
            var letters = driver.FindElement(By.XPath("/html"));

            // Act & Assert M
            letters.SendKeys("M");
            var expectedM = "You entered: M";
            var actualM = driver.FindElement(By.XPath("/html/body/div[2]/div/div/p[2]")).Text;
            Assert.AreEqual(expectedM, actualM);

            // Act & Assert Return
            letters.SendKeys(Keys.Return);
            var expectedReturn = "You entered: ENTER";
            var actualReturn = driver.FindElement(By.XPath("/html/body/div[2]/div/div/p[2]")).Text;
            Assert.AreEqual(expectedReturn, actualReturn);

            // Act & Assert PageUp
            letters.SendKeys(Keys.PageUp);
            var expectedUp = "You entered: PAGE_UP";
            var actualUp = driver.FindElement(By.XPath("/html/body/div[2]/div/div/p[2]")).Text;
            Assert.AreEqual(expectedUp, actualUp);

            // Clean up:
            driver.Close();
        }
    }
}