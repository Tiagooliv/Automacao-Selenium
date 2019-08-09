using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using System;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._01_Produtos
{
    [TestClass]
    public class TC_Produtos
    {
        private IWebDriver driver;
        private HomePageTHExPOS Url;
        private PoLogin_PDV Login;
        private Po_Menus Menu;
        private Po_Produto Pr;

        public TC_Produtos()
        {
            driver = new ChromeDriver();
            Url = new HomePageTHExPOS(driver);
            Login = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Pr = new Po_Produto(driver);
        }

        [TestMethod]
        public void AdicionarProduto()
        {
            Url.AdminTST();
            Login.Admin();
            Menu.Produtos();
            Pr.BtnAdicionarProduto();
            Pr.DadosProduto("Torta de limão - Aut", "002", "Sobremesas - Aut", "KG - Quilo", "4,50");
            Pr.Detalhes("Chá - Aut");
            Pr.Fiscais();
            Pr.BtnSalvar();
            Pr.ValidarCadastro("Torta de limão - Aut");
            Menu.Inicio();
        }
    }
}
