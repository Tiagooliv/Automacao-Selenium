using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.Interactions;
using System;
using PDV.Test.UI._2._Interactions;
using NUnit.Framework;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._01_Produtos
{
    [TestFixture]
    public class TC_Produtos
    {
        #region Fields
        private IWebDriver driver;
        HomePageTHExPOS Url;
        IntLogin LG;
        Po_Menus Menu;
        ValidarCadastro VC;
        IntProduto Ip;
        #endregion

        public TC_Produtos()
        {
            driver = new ChromeDriver();
            Url = new HomePageTHExPOS(driver);
            LG = new IntLogin(driver);
            Menu = new Po_Menus(driver);
            Ip = new IntProduto(driver);
            VC = new ValidarCadastro(driver);

        }

        [Test]
        public void AdicionarProduto()
        {
            Url.AdminTST();
            LG.LoginPOS();
            Menu.Produtos();
            Ip.BtnAdicionarProduto();
            Ip.DadosProduto("Pizza - Aut", "002", "Pizzas - Aut", "KG - Quilo", "4,50");
            Ip.Detalhes("Sabor da Pizza - Aut");
            Ip.Fiscais();
            Ip.BtnSalvar("Produto cadastrado com sucesso.");
            VC.ValidaCadastro("Pizza - Aut - Aut");
            //Ip.BtnEditar();
            //Ip.EditarProduto("Torta de limão_E - Aut", "003");
            Ip.Editar();
            Ip.BtnSalvar("Produto cadastrado com sucesso.");
            VC.ValidaCadastro("Torta de limão_E - Aut");
            Ip.DuplicarProduto();
            VC.ValidaCadastro("Torta de limão_E - Aut - Copy");
            Menu.Inicio();
        }
    }
}
