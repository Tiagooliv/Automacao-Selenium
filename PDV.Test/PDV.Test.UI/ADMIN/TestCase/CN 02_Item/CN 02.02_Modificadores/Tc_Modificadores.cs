using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;
using NUnit.Framework;
using PDV.Test.UI._1._CommonMethods;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._02_Modificadores
          
{
    [TestClass]
    public class Tc_Modificadores
    {
        #region Fields
        HomePageTHExPOS HP;
        PoLogin_PDV LG;
        Po_Menus Menu;
        Po_Modificadores Mod;
        ValidarCadastro VC;
        #endregion
        public Tc_Modificadores()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);
            Mod = new Po_Modificadores(driver);
            VC = new ValidarCadastro(driver);
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
            VC.ValidaCadastro("Chá - Aut");
            Menu.Inicio();
        }

        [TestMethod]
        public void EditarModificador()
        {
            
        }


    }
}
