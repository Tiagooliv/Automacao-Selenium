using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace PDV.Test.UI._1._CommonMethods
{
    public class ValidateSwitch
    {
        IWebDriver driver;

        public ValidateSwitch(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchAtivo(By locator, string NomeAtributo, string ValorAtributo, string Msg)
        {
            var Switch = driver.FindElement(locator).GetAttribute(NomeAtributo);

            if (Switch.Equals(ValorAtributo))
            {
                Assert.Fail(Msg);
            }

        }
    }
}
