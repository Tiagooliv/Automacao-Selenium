using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Test.UI._1._CommonMethods
{
    public class Keyboard
    {
        IWebDriver driver;

        public Keyboard(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Tab(By locator)
        {
            var key = driver.FindElement(locator);
            key.SendKeys(Keys.Tab);
        }
    }
}
