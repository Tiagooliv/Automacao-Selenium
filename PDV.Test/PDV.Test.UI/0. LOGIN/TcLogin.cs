using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;

namespace PDV.Test.UI.TestPlan.LG
{
    [TestClass]
    public class TcLG_POS
    {
        
        private HomePageTHExPOS HP;
        private PoLogin_PDV L;

        public TcLG_POS()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            L = new PoLogin_PDV(driver);
        }


        [TestMethod]
        public void AcessarPos()
        {
            HP.PosTST();
            L.POS();
        }

        [TestMethod]

        public void AcessarAdmin()
        {
            HP.AdminTST();
            L.Admin();
        }


        




    }
}
