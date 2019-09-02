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
        IntGrupoDeProdutos Gp;
        ValidarCadastro Vc;
        #endregion

        public Tc_GruposDeProdutos()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gp = new IntGrupoDeProdutos(driver);
            Vc = new ValidarCadastro(driver);
        }

        [TestMethod]
        public void AdicionarGrupo()

        {
            HP.AdminTST();
            LG.Admin();
            Menu.GruposDeProdutos();
            Gp.BtnAdicionarGrupo();
            Gp.DadosdoGrupo("Sobremesas - Aut", "Outros");
            Gp.IconeGrupo();
            Gp.BtnSalvar("Grupo criado com sucesso");
            Vc.ValidaCadastro("Sobremesas - Aut");
            Menu.Inicio();

        }

        public void EditarGrupo()
        {
            Gp.Editar();
            Gp.DadosdoGrupo("Sobremesas - Aut Editado", "Bebidas");
            Gp.BtnSalvar("Grupo atualizado com sucesso");
            Vc.ValidaCadastro("Sobremesas - Aut Editado");
            Menu.Inicio();
        }



    }
}
