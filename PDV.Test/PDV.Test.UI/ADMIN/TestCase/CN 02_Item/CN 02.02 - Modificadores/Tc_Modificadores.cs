using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using NUnit.Framework;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._02___Modificadores
{
    [TestClass]
    public class Tc_Modificadores
    {
        private HomePageTHExPOS HP;
        private PoLogin_PDV LG;
        private Po_Menus Menu;
        private Po_Modificadores Mod;
        public Tc_Modificadores()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Mod = new Po_Modificadores(driver);
        }                    

        [TestMethod]
        public void AdicionarModificador()
        {
            HP.AdminTST();
            LG.Admin();
            Menu.Modificadores();
            Mod.BtnAdicionarModificador();
            Mod.DadosDoModificador("Chá - Aut", "1", "2", "UN - Unidade");
            Mod.Modificador("Chá", "Chá de menta", "5");
            Mod.BtnSalvar();
            Mod.ValidarCadastro("Chá - Aut");
            Menu.Inicio();
        }

        [TestMethod]
        public void EditarModificador()
        {
            
        }


    }
}
