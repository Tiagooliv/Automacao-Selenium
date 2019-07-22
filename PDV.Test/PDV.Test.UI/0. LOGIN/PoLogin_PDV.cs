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
        private IWebDriver _driver;
        private WaitElement Wait;

        public PoLogin_PDV(IWebDriver driver)
        {
            this._driver = driver;
            Wait = new WaitElement(driver);
        }

        public void Admin()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));
            
        }

        public void POS()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));

            Thread.Sleep(10000);
        }


    }
}
