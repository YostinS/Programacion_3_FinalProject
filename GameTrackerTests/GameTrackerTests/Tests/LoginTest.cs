using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace GameTrackerTests
{
    public class LoginTest : BaseTest
    {
        //PRUEBA 1: HISTORIA DE USUARIO 1
        //CAMINO FELIZ: Ingresar con usuario y contraseña correctos
        [Test]
        public void Login_HappyPath()
        {
            Thread.Sleep(2000);

            driver.FindElement(By.Id("Username"))
                  .SendKeys("admin");

            driver.FindElement(By.Id("Password"))
                  .SendKeys("123456");

            TakeScreenshot("BeforeLogin");

            Thread.Sleep(1000);

            driver.FindElement(By.CssSelector("button[type='submit']"))
                  .Click();

            Thread.Sleep(2000);

            TakeScreenshot("AfterLogin");

            Assert.IsTrue(driver.Url.Contains("Games"));
        }

        //CAMINO TRISTE: Ingresar con usuario correcto y contraseña incorrecta
        [Test]
        public void Login_InvalidPassword()
        {
            driver.FindElement(By.Id("Username"))
                  .SendKeys("admin");

            driver.FindElement(By.Id("Password"))
                  .SendKeys("wrongpassword");

            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsFalse(
                driver.Url.Contains("Games"));
        }

        //CAMINO LIMITES: Ingresar con campos vacíos
        [Test]
        public void Login_EmptyFields()
        {
            driver.FindElement(
                By.CssSelector("button[type='submit']"))
                .Click();

            Assert.IsFalse(
                driver.Url.Contains("Games"));
        }

   




    }
}
