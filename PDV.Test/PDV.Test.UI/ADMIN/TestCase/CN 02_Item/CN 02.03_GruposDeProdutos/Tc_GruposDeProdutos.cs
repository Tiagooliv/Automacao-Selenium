using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using System;
using System.Threading;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_ITEM.CN_02._03_GruposDeProdutos

{
    [TestClass]
    public class Tc_GruposDeProdutos

    {
        private HomePageTHExPOS HP;
        private PoLogin_PDV LG;
        private Po_Menus Menu;
        private Po_GruposDeProdutos Gr;

        public Tc_GruposDeProdutos()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_GruposDeProdutos(driver);
        }

        [TestMethod]
        public void AdicionarGrupo()

        {
            HP.AdminTST();
            LG.Admin();
            Menu.GruposDeProdutos();
            Gr.BtnAdicionarGrupo();
            Gr.DadosdoGrupo("Bebidas não Alcoólicas - Automatizado", "Bebidas");
            Gr.IconeGrupo();
            Gr.BtnSalvar();
            Gr.ValidarCadastro("Bebidas não Alcoólicas - Automatizado");
            Menu.Inicio();

        }



    }
}
