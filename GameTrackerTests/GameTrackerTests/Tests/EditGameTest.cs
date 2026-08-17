using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace GameTrackerTests.Test
{
    public class EditGameTest : BaseTest
    {
        [Test]
        public void EditGame_HappyPath()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Edit/1");

            Thread.Sleep(1000);

            var input =
                driver.FindElement(
                    By.Id("Game_Name"));

            input.Clear();

            input.SendKeys(
                "Minecraft Updated");

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsTrue(
                driver.PageSource.Contains(
                    "Minecraft Updated"));
        }

        [Test]
        public void EditGame_InvalidId()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Edit/999");

            Assert.IsFalse(
                driver.Url.Contains(
                    "Edit/999"));
        }

        [Test]
        public void EditGame_LongName()
        {
            string longName =
                new string('Z', 100);

            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Edit/1");

            Thread.Sleep(1000);

            var input =
                driver.FindElement(
                    By.Id("Game_Name"));

            input.Clear();

            input.SendKeys(longName);

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsTrue(
                driver.PageSource.Contains(longName));
        }


    }
}
