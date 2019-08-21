using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));

        }

        public void POS()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));

            Thread.Sleep(10000);
        }


    }
}
