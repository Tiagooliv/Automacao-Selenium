using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;

namespace PDV.Test.UI.TestPlan.Login
{
    [TestClass]
    public class TcLogin_POS
    {
        
        private UrlPDV Url;
        private PoLogin_PDV L;

        public TcLogin_POS()
        {
            IWebDriver driver = new ChromeDriver();
            Url = new UrlPDV(driver);
            L = new PoLogin_PDV(driver);
        }


        [TestMethod]
        public void AcessarPos()
        {
            Url.PosTST();
            L.POS();
        }

        [TestMethod]

        public void AcessarAdmin()
        {
            Url.AdminTST();
            L.Admin();
        }


        




    }
}
