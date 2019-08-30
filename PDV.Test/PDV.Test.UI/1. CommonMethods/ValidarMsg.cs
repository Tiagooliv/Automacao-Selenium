using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;

namespace PDV.Test.UI._1._CommonMethods
{
    [TestClass]
    public class ValidarMsg
    {
        IWebDriver driver;
        WaitElement Wait;
        string msg = "/html/body/thf-toaster/div/div";

        public ValidarMsg(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);                  
        }

        [TestMethod]
        public void ValidaMsg(string Msg)
        {
            Wait.LocateElement(By.XPath(msg));
            var text = driver.FindElement(By.XPath(msg)).Text;
            Assert.AreEqual(Msg, text);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(msg)).Click();
        }
    
    }
}
