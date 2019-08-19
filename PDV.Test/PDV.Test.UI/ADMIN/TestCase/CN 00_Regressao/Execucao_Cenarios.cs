using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;


namespace PDV.Test.UI.ADMIN.TestCase.CN_00_Regressao
{
    [TestClass]
    public class Execucao_Cenarios
    {
        #region Fields
        private HomePageTHExPOS HP;
        private PoLogin_PDV LG;
        private Po_Menus Menu;
        private Po_GruposDeProdutos Gr;
        private Po_Modificadores Mod;
        private Po_Produto Pr;
        private Po_PDV PDV;
        #endregion

        public Execucao_Cenarios()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_GruposDeProdutos(driver);
            Mod = new Po_Modificadores(driver);
            Pr = new Po_Produto(driver);
            PDV = new Po_PDV(driver);

        }

        [TestMethod]
        public void Regressao_Cadastros()
        {
            HP.AdminTST();
            LG.Admin();

            //Grupos

            Menu.GruposDeProdutos();
            Gr.BtnAdicionarGrupo();
            Gr.DadosdoGrupo("Sobremesas - Aut", "Bebidas");
            Gr.IconeGrupo();
            Gr.BtnSalvar();
            Gr.ValidarCadastro("Sobremesas - Aut");

            //Modificadores

            Menu.Modificadores();
            Mod.BtnAdicionarModificador();
            Mod.DadosDoModificador("Chá - Aut", "1", "2", "UN - Unidade");
            Mod.Modificador("Chá", "Chá de menta", "5");
            Mod.BtnSalvar();
            Mod.ValidarCadastro("Chá - Aut");

            //Produtos

            Menu.Produtos();
            Pr.BtnAdicionarProduto();
            Pr.DadosProduto("Torta de limão - Aut", "002", "Sobremesas - Aut", "KG - Quilo", "4,50");
            Pr.Detalhes("Chá - Aut");
            Pr.Fiscais();
            Pr.BtnSalvar();
            Pr.ValidarCadastro("Torta de limão - Aut");

            //PDV

            Menu.PDV();
            PDV.BtnAdicionarPDV();
            PDV.Dados("PDV - Aut", "cm", "Portugal", "Espanhol");
            PDV.TaxaServico("7", "10", "13");
            PDV.AssociarItens("Torta de Limão - Aut");
            PDV.BtnSalvar();
            PDV.ValidarCadastro("PDV - Aut");
            Menu.Inicio();


        }


    }
}
