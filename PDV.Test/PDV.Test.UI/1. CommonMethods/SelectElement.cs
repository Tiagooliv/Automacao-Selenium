using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PDV.Test.UI._1._CommonMethods
{
    public class Select_Element
    {
        private IWebDriver driver;

        public Select_Element(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ByText(By locator, string Text)
        {
            SelectElement element = new SelectElement(driver.FindElement(locator));
            element.SelectByText(Text);
        }

        public void ByValue(By locator, string Value)
        {
            SelectElement element = new SelectElement(driver.FindElement(locator));
            element.SelectByValue(Value);
        }

    }


}
