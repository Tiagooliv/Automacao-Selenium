using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace PDV.Test.UI.POS.CommonMethods
{
    public class WaitElement
    {
        IWebDriver _driver;
        WebDriverWait Wait;
        public WaitElement(IWebDriver driver)
        {
            this._driver = driver;
            Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public void LocateElement(By locator)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));            
        }

        public void LocateElementAndClick(By locator)
        {
            var Element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            Element.Click();           
        }

        public void LocateElementAndClick_x2(By locator)
        {
            for (int i = 0; i < 2; i++)
            {
                var Element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                Element.Click();
                Thread.Sleep(500);
            }
        }

        public void LocateElementAndClick_x3(By locator)
        {
            for (int i = 0; i < 3; i++)
            {
                var Element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                Element.Click();
                Thread.Sleep(500);
            }
        }

    }
}
