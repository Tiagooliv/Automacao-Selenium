using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._0._Login;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._02_Modificadores;
using PDV.Test.UI.ADMIN.TestCase.CN_02_ITEM.CN_02._03_GruposDeProdutos;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.Interactions;

namespace PDV.Test.UI.ADMIN.TestCase.CN_00_Regressao
{
    [TestFixture]
    public class Execucao_Cenarios
    {
        #region Fields

        HomePageTHExPOS HP;
        IntLogin LG;
        Po_Menus Menu;
        IntGrupoDeProdutos Gp;
        IntModificadores Mod;
        IntProduto Pr;
        IntPDV PDV;
        ValidarCadastro Vc;
        Tc_GruposDeProdutos Tc_Grupo;
        Tc_Modificadores Tc_Modificadores;
        IWebDriver driver;


        #endregion

        public Execucao_Cenarios()
        {
            //IWebDriver driver = new ChromeDriver();
            //HP = new HomePageTHExPOS(driver);
            //LG = new IntLogin(driver);
            //Menu = new Po_Menus(driver);
            //Gp = new IntGrupoDeProdutos(driver);
            //Mod = new IntModificadores(driver);
            //Pr = new IntProduto(driver);
            //PDV = new IntPDV(driver);
            //Vc = new ValidarCadastro(driver);
            Tc_Grupo = new Tc_GruposDeProdutos();
            Tc_Modificadores = new Tc_Modificadores(/*driver*/);


        }

        [Test]
        public void Regressao_Cadastros()
        {
            //HP.AdminTST();
            //LG.LoginPOS();

            //Grupos

            Tc_Grupo.AdicionarGrupo();
            Tc_Modificadores.AdicionarModificador();
            

            //Menu.GruposDeProdutos();
            //Gp.BtnAdicionarGrupo();
            //Gp.DadosdoGrupo("Sobremesas - Aut", "Bebidas");
            //Gp.IconeGrupo();
            //Gp.BtnSalvar("Grupo criado com sucesso");
            //Vc.ValidaCadastro("Sobremesas - Aut");

            //Modificadores

            //Menu.Modificadores();
            //Mod.BtnAdicionarModificador();
            //Mod.DadosDoModificador("Chá - Aut", "1", "2", "UN - Unidade");
            //Mod.Modificador("Chá", "Chá de menta", "5");
            //Mod.BtnSalvar("Modificador cadastrado com sucesso.");
            //Vc.ValidaCadastro("Chá - Aut");

            //Produtos

            //Menu.Produtos();
            //Pr.BtnAdicionarProduto();
            //Pr.DadosProduto("Torta de limão - Aut", "002", "Sobremesas - Aut", "KG - Quilo", "7894900019896", "4,50");
            //Pr.Detalhes("Chá - Aut");
            //Pr.Fiscais("20081100");
            //Pr.BtnSalvar("Produto cadastrado com sucesso.");
            //Vc.ValidaCadastro("Torta de limão - Aut");

            //PDV

            //Menu.PDV();
            //PDV.BtnAdicionarPDV();
            //PDV.Dados("PDV - Aut", "cm", "Portugal", "Espanhol");
            //PDV.TaxaServico("7", "10", "13");
            //PDV.AssociarItens("Torta de limão - Aut");
            //PDV.BtnSalvar("Ponto de venda cadastrado com sucesso.");
            //Vc.ValidaCadastro("PDV - Aut");
            //Menu.Inicio();

        }


    }
}
