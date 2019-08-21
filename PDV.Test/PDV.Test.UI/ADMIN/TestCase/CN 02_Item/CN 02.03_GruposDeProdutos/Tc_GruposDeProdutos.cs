using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
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
        #region Fields
        HomePageTHExPOS HP;
        PoLogin_PDV LG;
        Po_Menus Menu;
        Po_GruposDeProdutos Gr;
        ValidarCadastro VC;
        #endregion

        public Tc_GruposDeProdutos()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_GruposDeProdutos(driver);
            VC = new ValidarCadastro(driver);
        }

        [TestMethod]
        public void AdicionarGrupo()

        {
            HP.AdminTST();
            LG.Admin();
            Menu.GruposDeProdutos();
            Gr.BtnAdicionarGrupo();
            Gr.DadosdoGrupo("Sobremesas - Aut", "Outros");
            Gr.IconeGrupo();
            Gr.BtnSalvar();
            VC.ValidaCadastro("Sobremesas - Aut");
            Menu.Inicio();

        }



    }
}
