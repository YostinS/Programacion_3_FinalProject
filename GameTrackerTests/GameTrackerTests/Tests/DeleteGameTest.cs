using NUnit.Framework;
using OpenQA.Selenium;

namespace GameTrackerTests
{
    public class DeleteGameTest : BaseTest
    {
        [Test]
        public void DeleteGame_HappyPath()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Delete/1");

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.Pass();
        }

        [Test]
        public void DeleteGame_InvalidId()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Delete/999");

            Assert.IsFalse(
                driver.Url.Contains("999"));
        }

        [Test]
        public void DeleteGame_LastRecord()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Delete/1");

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsFalse(
            driver.PageSource.Contains("Minecraft"));
        }
    }
}