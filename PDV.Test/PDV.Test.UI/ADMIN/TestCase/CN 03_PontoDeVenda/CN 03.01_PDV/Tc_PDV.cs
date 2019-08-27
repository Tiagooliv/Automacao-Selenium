using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.Interactions;
using PDV.Test.UI.PageObjects.PDV;

namespace PDV.Test.UI.ADMIN.TestCase.CN_03_PontoDeVenda.CN_03._01_PDV
{
    [TestClass]
    public class Tc_PDV
    {
        private HomePageTHExPOS HP;
        private PoLogin_PDV LG;
        private Po_Menus Menu;
        private IntPDV PDV;
        private ValidarCadastro VC;

        public Tc_PDV()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            PDV = new IntPDV(driver);
            VC = new ValidarCadastro(driver);
        }

        [TestMethod]
        public void AdicionarPDV()
        {
            HP.AdminTST();
            LG.Admin();
            Menu.PDV();
            PDV.BtnAdicionarPDV();
            PDV.Dados("PDV - Aut", "cm", "Portugal", "Espanhol");
            PDV.TaxaServico("7", "10", "13");
            PDV.AssociarItens("Churrasco");
            PDV.BtnSalvar();
            VC.ValidaCadastro("PDV - Aut");
            Menu.Inicio();
            
        }
    }
}
