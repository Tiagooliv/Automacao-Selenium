using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using NUnit.Framework;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._02_Modificadores
          
{
    [TestFixture]
    public class Tc_Modificadores
    {
        #region Fields
        HomePageTHExPOS HP;
        IntLogin LG;
        Po_Menus Menu;
        IntModificadores Mod;
        ValidarCadastro VC;
        #endregion
        public Tc_Modificadores()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            LG = new IntLogin(driver);
            Menu = new Po_Menus(driver);
            Mod = new IntModificadores(driver);
            VC = new ValidarCadastro(driver);
        }                    

        [Test]
        public void AdicionarModificador()
        {
            HP.AdminTST();
            LG.LoginPOS();
            Menu.Modificadores();
            Mod.BtnAdicionarModificador();
            Mod.DadosDoModificador("Sabor da Pizza - Aut", "1", "2", "UN - Unidade");
            Mod.Modificador("Calabresa", "Calabresa com cebola", "5");
            Mod.BtnSalvar("Modificador cadastrado com sucesso.");
            VC.ValidaCadastro("Sabor da Pizza - Aut");
            
        }

        [Test]
        public void EditarModificador()
        {
            
        }


    }
}
