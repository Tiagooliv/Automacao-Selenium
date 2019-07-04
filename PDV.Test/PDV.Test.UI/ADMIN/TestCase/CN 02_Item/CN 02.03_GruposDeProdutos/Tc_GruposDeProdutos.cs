using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using System;

namespace TestCase.CN_02_ITEM.CN_02._03_GruposDeProdutos.CN_02._03._01_AdicionarGrupo    

{
    [TestClass]
   public class Tc_GruposDeProdutos        
        
    {      
        private IWebDriver driver;
        private UrlPDV Url;
        private PoLogin_PDV Login;
        private Po_Menus Menu;
        private Po_GruposDeProdutos Gr;

        public Tc_GruposDeProdutos()
        {
            driver = new ChromeDriver();
            Url = new UrlPDV(driver);
            Login = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_GruposDeProdutos(driver);
        }

        [TestMethod]
        public void AdicionarGrupo()
        {
            Url.AdminTST();
            Login.Admin();
            Menu.GruposDeProdutos();
            Gr.BtnAdicionarGrupo();
            Gr.DadosdoGrupo("A Bebidas não Alcoólicas - Automatizado", "Bebidas");
            Gr.IconeGrupo();
            Gr.BtnSalvar();
            Gr.ValidaCadastro("A Bebidas não Alcoólicas - Automatizado");
        }
    }
}
