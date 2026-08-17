using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace GameTrackerTests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(
                "https://localhost:7050/Login"
            );
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        protected void TakeScreenshot(string fileName)
        {
            string folder =
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Screenshots"
                );

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var screenshot =
                ((ITakesScreenshot)driver)
                .GetScreenshot();

            string filePath =
                Path.Combine(
                    folder,
                    $"{fileName}.png"
                );

            screenshot.SaveAsFile(filePath);
        }

    }
}