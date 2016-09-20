using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;



namespace Automatization_Test
{
    [TestFixture]
    public class Test1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://juntoz.com/";
            verificationErrors = new StringBuilder();
        }


        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }

       [TestMethod]
        public void TheCabeceraTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")));
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-stores']/a/span[2]/span")));
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[2]")));
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.LinkText("Todas las tiendas")));
            try
            {
                NUnit.Framework.Assert.AreEqual("Todas las tiendas", driver.FindElement(By.LinkText("Todas las tiendas")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")));
            try
            {
                NUnit.Framework.Assert.AreEqual("", driver.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span[2]/i")));
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span")));
            try
            {
                NUnit.Framework.Assert.AreEqual("tu tienda", driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span[2]/span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.Id("btncartitem")));
            try
            {
                NUnit.Framework.Assert.AreEqual("Mi Carrito", driver.FindElement(By.Id("btncartitem")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.Id("btnaccount")));
            try
            {
                NUnit.Framework.Assert.AreEqual("Mi Hola Cuenta", driver.FindElement(By.Id("btnaccount")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            NUnit.Framework.Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-categories']/a/span[2]/span[2]")));
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    
}
}
