using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.POS.CommonMethods;

namespace PDV.Test.UI.PageObjects.PDV
{

    public class PoLogin_PDV

    {
        private IWebDriver driver;
        private WaitElement Wait;

        public PoLogin_PDV(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void Admin()
        {
            var email = driver.FindElement(By.XPath("//div/div[2]/input"));
            email.Clear();
            email.SendKeys("cm@totvs.com.br");

            var senha = driver.FindElement(By.XPath("//div/div[2]/thf-password/thf-field-container/div/div[2]/input"));
            senha.Clear();
            senha.SendKeys("5>E&Jg4,");

            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));
            Thread.Sleep(5000);

            Wait.LocateElement(By.ClassName("thf-page-header-title"));
            var title = driver.FindElement(By.ClassName("thf-page-header-title")).Text;
            Assert.AreEqual("Estabelecimentos", title);
            

            driver.FindElement(By.XPath("//div/div[2]/input")).SendKeys("sqa");
            driver.FindElement(By.ClassName("initials-header")).Click();
            Thread.Sleep(2000);
            
        }

        public void POS()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));
            Thread.Sleep(10000);
        }


    }
}
