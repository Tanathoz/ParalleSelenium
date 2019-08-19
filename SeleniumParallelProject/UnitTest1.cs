using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelProject
{
    [TestFixture]
    public class FirefoxTesting
    {
        [Test]
        public void FirefoxGoogleTest()
        {

        }
    }

    [TestFixture]
    [Parallelizable]
    public class IExplorerTesting : Hooks
    {
        public IExplorerTesting() : base(BrowserType.IExplorer)
        {

        }
        [Test]
        public void IExplorerGoogleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("gLFyf")).SendKeys("AutomationTest");
            
            driver.FindElement(By.Name("q")).SendKeys(Keys.Tab);
            driver.FindElement(By.Name("btnK")).Click();
            Assert.That(driver.PageSource.Contains("AutomationTest"), Is.EqualTo(true), "The text AutomationTest does not exist");
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting: Hooks
    {
        public ChromeTesting():base(BrowserType.Chrome)
        {

        }
        [Test]
        public void ChromeGoogleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            
            driver.FindElement(By.Name("q")).SendKeys("Selenium");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
           // driver.FindElement(By.Name("btnK")).Click();
            Assert.That(driver.PageSource.Contains("Selenium"), Is.EqualTo(true), "The text selenium does not exist");

        }
    }
}
