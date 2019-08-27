using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.Interactions;
using PDV.Test.UI.PageObjects.PDV;


namespace PDV.Test.UI.ADMIN.TestCase.CN_00_Regressao
{
    [TestClass]
    public class Execucao_Cenarios
    {
        #region Fields
        HomePageTHExPOS HP;
        PoLogin_PDV LG;
        Po_Menus Menu;
        IntGrupoDeProdutos Gp;
        IntModificadores Mod;
        IntProduto Pr;
        IntPDV PDV;
        ValidarCadastro Vc;
        #endregion

        public Execucao_Cenarios()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gp = new IntGrupoDeProdutos(driver);
            Mod = new IntModificadores(driver);
            Pr = new IntProduto(driver);
            PDV = new IntPDV(driver);
            Vc = new ValidarCadastro(driver);
        }

        [TestMethod]
        public void Regressao_Cadastros()
        {
            HP.AdminTST();
            LG.Admin();

            //Grupos

            Menu.GruposDeProdutos();
            Gp.BtnAdicionarGrupo();
            Gp.DadosdoGrupo("Sobremesas - Aut", "Bebidas");
            Gp.IconeGrupo();
            Gp.BtnSalvar();
            Vc.ValidaCadastro("Sobremesas - Aut");

            //Modificadores

            Menu.Modificadores();
            Mod.BtnAdicionarModificador();
            Mod.DadosDoModificador("Chá - Aut", "1", "2", "UN - Unidade");
            Mod.Modificador("Chá", "Chá de menta", "5");
            Mod.BtnSalvar();
            Vc.ValidaCadastro("Chá - Aut");

            //Produtos

            Menu.Produtos();
            Pr.BtnAdicionarProduto();
            Pr.DadosProduto("Torta de limão - Aut", "002", "Sobremesas - Aut", "KG - Quilo", "4,50");
            Pr.Detalhes("Chá - Aut");
            Pr.Fiscais();
            Pr.BtnSalvar();
            Vc.ValidaCadastro("Torta de limão - Aut");

            //PDV

            Menu.PDV();
            PDV.BtnAdicionarPDV();
            PDV.Dados("PDV - Aut", "cm", "Portugal", "Espanhol");
            PDV.TaxaServico("7", "10", "13");
            PDV.AssociarItens("Torta de limão - Aut");
            PDV.BtnSalvar();
            Vc.ValidaCadastro("PDV - Aut");
            Menu.Inicio();

        }


    }
}
