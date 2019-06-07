using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.POS.CommonMethods;

namespace PDV.Test.UI.PageObjects.PDV
{

    public class PoLogin_POS

    {
        private IWebDriver _driver;
        private WaitElement Wait;

        public PoLogin_POS(IWebDriver driver)
        {
            this._driver = driver;
            Wait = new WaitElement(driver);
        }

        public void Login()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-container/div/div/form/div/thf-button/button"));       
                      
        }

        public void Test ()
        {

        }


    }
}
