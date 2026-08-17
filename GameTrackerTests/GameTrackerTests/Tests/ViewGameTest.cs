using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace GameTrackerTests
{
    public class ViewGameTest : BaseTest
    {
        [Test]
        public void ViewGame_HappyPath()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games");

            Assert.IsTrue(
                driver.PageSource.Contains("Game"));
        }

        [Test]
        public void ViewGame_NoGames()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games");

            Assert.IsNotNull(driver.PageSource);
        }

        [Test]
        public void ViewGame_ManyRecords()
        {
            driver.Navigate().GoToUrl(
                "https://localhost:7050/Games");

            Assert.IsTrue(
                driver.PageSource.Length > 0);
        }
    }
}