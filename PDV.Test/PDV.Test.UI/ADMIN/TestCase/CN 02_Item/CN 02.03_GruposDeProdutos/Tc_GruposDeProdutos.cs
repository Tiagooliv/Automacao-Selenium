using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using System;
using System.Threading;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_ITEM.CN_02._03_GruposDeProdutos

{
    [TestFixture]
    public class Tc_GruposDeProdutos

    {
        #region Fields
        HomePageTHExPOS HP;
        IntLogin LG;
        Po_Menus Menu;
        IntGrupoDeProdutos Gp;
        ValidarCadastro Vc;
        #endregion

        public Tc_GruposDeProdutos()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new IntLogin(driver);
            Menu = new Po_Menus(driver);
            Gp = new IntGrupoDeProdutos(driver);
            Vc = new ValidarCadastro(driver);
        }

        [Test]
        public void AdicionarGrupo()

        {
            HP.AdminTST();
            LG.LoginPOS();
            Menu.GruposDeProdutos();
            Gp.BtnAdicionarGrupo();
            Gp.DadosdoGrupo("Pizzas - Aut", "Outros");
            Gp.IconeGrupo();
            Gp.BtnSalvar("Grupo criado com sucesso");
            Vc.ValidaCadastro("Pizzas - Aut");
            
        }

        [Test]
        public void EditarGrupo()
        {
            HP.AdminTST();
            LG.LoginPOS();
            Menu.GruposDeProdutos();
            Vc.PesqCad("Sobremesas - Aut");
            Gp.Editar();
            Gp.DadosdoGrupo("Pizzas - Aut Editado", "Bebidas");
            Gp.BtnSalvar("Grupo atualizado com sucesso");
            Vc.ValidaCadastro("Pizzas - Aut Editado");
            //Menu.Inicio();
        }

        [Test]
        public void ExcluirGrupo()
        {
            //HP.AdminTST();
            //LG.Admin();
            //Menu.GruposDeProdutos();
            //Vc.PesqCad("Sobremesas - Aut");
            Gp.Excluir("Grupo removido com sucesso.");
        }



    }
}
