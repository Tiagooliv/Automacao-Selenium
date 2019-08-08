using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Test.UI.CommonMethods.Utils
{
    public enum Browser
    {
        Chrome,
        Firefox,
    }
    public class TestLocalTools
    {
        private IWebDriver _driver;

        public IWebDriver Instance(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    if (_driver != null) return _driver;
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    return _driver;

                case Browser.Firefox:
                    if (_driver != null) return _driver;
                    _driver = new FirefoxDriver();
                    _driver.Manage().Window.Maximize();
                    return _driver;

                default: throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }
        }

        public static class HPAdminTst
        {
            public const string HPAdmin = "https://admin-pos-front-tst.totvscmnet-cloud.net/auth/LG";
        }

        public static class HPPosTst
        {
            public const string HPPos = "https://pos-front-tst.totvscmnet-cloud.net/auth/LG";
        }

    }
}
