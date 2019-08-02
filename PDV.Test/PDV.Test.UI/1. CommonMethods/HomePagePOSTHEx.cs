using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace PDV.Test.UI.CommonMethods.Utils
{
   public class HomePagePOSTHEx
    {
        private IWebDriver driver;
        public HomePagePOSTHEx(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PosTST()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://pos-front-tst.totvscmnet-cloud.net/auth/login");            
                                             
            var title =  driver.Title;
            Assert.AreEqual("TOTVS PDV Food", title);
        }

        public void AdminTST()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://admin-pos-front-tst.totvscmnet-cloud.net/auth/login");            
            
            var title = driver.Title;
            Assert.AreEqual("Admin", title);

        }

    }

}
