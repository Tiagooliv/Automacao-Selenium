﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace PDV.Test.UI.CommonMethods.Utils
{
   public class HomePageTHExPOS
    {
        private IWebDriver driver;
        public HomePageTHExPOS(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PosTST()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tst.thexpos.net/auth/login");            
                                             
            var title =  driver.Title;
            Assert.AreEqual("TOTVS PDV Food", title);
        }

        public void AdminTST()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://admin-tst.thexpos.net/auth/login");            
            
            var title = driver.Title;
            Assert.AreEqual("THEx POS Management", title);

        }

    }

}