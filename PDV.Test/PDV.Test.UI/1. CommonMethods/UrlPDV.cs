using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PDV.Test.UI.CommonMethods.Utils
{
   public class UrlPDV
    {
        private IWebDriver driver;
        public UrlPDV(IWebDriver driver)
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

        public void AdminTST()
        {
            driver.Navigate().GoToUrl("https://admin-pos-front-tst.totvscmnet-cloud.net/auth/login");
            driver.Manage().Window.Maximize();
            
            var title = driver.Title;
            Assert.AreEqual("Admin", title);


        }

    }

}
