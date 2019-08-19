using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
namespace SeleniumParallelProject
{
    public enum BrowserType
    {
        Firefox,
        Chrome,
        IExplorer
    }
    [TestFixture]
    public class Hooks : Base
    {

        private BrowserType browser;
        public Hooks(BrowserType browsertype)
        {
            browser = browsertype;
        }

        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(browser);
        }

        private void ChooseDriverInstance (BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                driver = new ChromeDriver();
            else if (browserType == BrowserType.IExplorer)
                driver = new InternetExplorerDriver();
        }
    }
}
