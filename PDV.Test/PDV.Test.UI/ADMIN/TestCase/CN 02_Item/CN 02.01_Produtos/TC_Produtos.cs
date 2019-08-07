using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using System;

namespace TestCase.CN_02_ITEM.CN_02._01_Produtos.CN_02._01._01_CadastrarProduto
{
    [TestClass]
    public class TC_Produtos
    {
        private IWebDriver driver;
        private UrlPDV Url;
        private PoLogin_PDV Login;
        private Po_Menus Menu;
        private Po_Produto Gr;

        public TC_Produtos()
        {
            driver = new ChromeDriver();
            Url = new UrlPDV(driver);
            Login = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_Produto(driver);
        }

        [TestMethod]
        public void CadastrarProduto()
        {
            Url.AdminTST();
            Login.Admin();
            Menu.Produtos();
            Gr.BtnAdicionarProduto();
            Gr.DadosProduto("Teste de produto", "002", "Grupo sem Ícone", "KG - Quilo", "1,00");
            Gr.Detalhes("Molho - Aut");
            Gr.Fiscais();
            Gr.BtnSalvar();
            Gr.ValidarCadastro("Teste de produto");
        }
    }
}
