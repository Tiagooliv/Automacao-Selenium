﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Test.UI.CommonMethods.Utils
{
    class UrlPos
    {
        private IWebDriver driver;
        public UrlPos(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PosTST()
        {
            driver.Navigate().GoToUrl("https://pos-front-tst.totvscmnet-cloud.net/auth/login");
            driver.Manage().Window.Maximize();
                                 
            var title =  driver.Title;
            Assert.AreEqual("TOTVS PDV Food", title);
        }

    }

}
