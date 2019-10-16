using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.Interactions;

namespace PDV.Test.UI.ADMIN.TestCase.CN_03_PontoDeVenda.CN_03._01_PDV
{
    [TestFixture]
    public class Tc_PDV
    {
        private HomePageTHExPOS HP;
        private IntLogin LG;
        private Po_Menus Menu;
        private IntPDV PDV;
        private ValidarCadastro VC;

        public Tc_PDV()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new IntLogin(driver);
            Menu = new Po_Menus(driver);
            PDV = new IntPDV(driver);
            VC = new ValidarCadastro(driver);
        }

        [Test]
        public void AdicionarPDV()
        {
            HP.AdminTST();
            LG.LoginPOS();
            Menu.PDV();
            PDV.BtnAdicionarPDV();
            PDV.Dados("PDV - Aut", "SQUAD PDV S/A", "Brasil", "Português");
            PDV.TaxaServico("7", "10", "13");
            PDV.AssociarItens("Cigarro");
            PDV.BtnSalvar("Ponto de venda cadastrado com sucesso.");
            VC.ValidaCadastro("PDV - Aut");
            Menu.Inicio();
            
        }
    }
}
