using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;

namespace PDV.Test.UI.ADMIN.TestCase.CN_03_PontoDeVenda.CN_03._01_PDV
{
    [TestClass]
    public class Tc_PDV
    {
        private HomePageTHExPOS HP;
        private PoLogin_PDV LG;
        private Po_Menus Menu;
        private Po_PDV PDV;

        public Tc_PDV()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            PDV = new Po_PDV(driver);
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
            PDV.AssociarItens("Torta de Limão - Aut");
            PDV.BtnSalvar();
            PDV.ValidarCadastro("PDV - Aut");
            Menu.Inicio();


        }
    }
}
