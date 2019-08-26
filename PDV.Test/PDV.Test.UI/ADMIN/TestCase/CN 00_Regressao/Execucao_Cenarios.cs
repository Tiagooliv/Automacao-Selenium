using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using PDV.Test.UI.Interactions;

namespace PDV.Test.UI.ADMIN.TestCase.CN_00_Regressao
{
    [TestClass]
    public class Execucao_Cenarios 
    {
        #region Fields
        HomePageTHExPOS HP;
        PoLogin_PDV LG;
        Po_Menus Menu;
        Po_GruposDeProdutos Gr;
        Po_Modificadores Mod;
        IntProduto Ip;
        Po_PDV PDV;
        ValidarCadastro VC;
        #endregion

        public Execucao_Cenarios()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Gr = new Po_GruposDeProdutos(driver);
            Mod = new Po_Modificadores(driver);
            Ip = new IntProduto(driver);
            PDV = new Po_PDV(driver);
            VC = new ValidarCadastro(driver);
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
            VC.ValidaCadastro("Sobremesas - Aut");

            //Modificadores

            Menu.Modificadores();
            Mod.BtnAdicionarModificador();
            Mod.DadosDoModificador("Chá - Aut", "1", "2", "UN - Unidade");
            Mod.Modificador("Chá", "Chá de menta", "5");
            Mod.BtnSalvar();
            VC.ValidaCadastro("Chá - Aut");

            //Produtos

            Menu.Produtos();
            Ip.BtnAdicionarProduto();
            Ip.DadosProduto("Torta de limão - Aut", "002", "Sobremesas - Aut", "KG - Quilo", "4,50");
            Ip.Detalhes("Chá - Aut");
            Ip.Fiscais();
            Ip.BtnSalvar();
            VC.ValidaCadastro("Torta de limão - Aut");

            //PDV

            Menu.PDV();
            PDV.BtnAdicionarPDV();
            PDV.Dados("PDV - Aut", "cm", "Portugal", "Espanhol");
            PDV.TaxaServico("7", "10", "13");
            PDV.AssociarItens("Torta de limão - Aut");
            PDV.BtnSalvar();
            VC.ValidaCadastro("PDV - Aut");
            Menu.Inicio();

        }


    }
}
