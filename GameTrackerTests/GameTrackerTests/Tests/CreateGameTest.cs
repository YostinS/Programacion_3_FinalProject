using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace GameTrackerTests
{
    public class CreateGameTest : BaseTest
    {
        [Test]
        public void CreateGame_HappyPath()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Create"
            );

            Thread.Sleep(1000);

            driver.FindElement(
                By.Id("Game_Name"))
                .SendKeys("Minecraft");

            driver.FindElement(
                By.Id("Game_Status"))
                .SendKeys("Pending");

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsTrue(
                driver.PageSource.Contains("Minecraft"));
        }

        [Test]
        public void CreateGame_EmptyName()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Create");

            Thread.Sleep(1000);

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsTrue(
                driver.PageSource.Contains("required")
                ||
                driver.PageSource.Contains("Name"));
        }

        [Test]
        public void CreateGame_LongName()
        {
            string longName =
                new string('A', 100);

            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games/Create");

            Thread.Sleep(1000);

            driver.FindElement(By.Id("Game_Name"))
                  .SendKeys(longName);

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsTrue(
                driver.PageSource.Contains(longName));
        }

    }
}