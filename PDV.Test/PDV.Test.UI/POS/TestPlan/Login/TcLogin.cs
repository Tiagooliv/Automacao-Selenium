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
        
        private UrlPos Url;
        private PoLogin_POS L;

        public TcLogin_POS()
        {
            IWebDriver driver = new ChromeDriver();
            Url = new UrlPos(driver);
            L = new PoLogin_POS(driver);
        }


        [TestMethod]
        public void AcessarPos()
        {
            Url.PosTST();
            L.Login();
        }

        




    }
}
