using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;
using PDV.Test.UI.PageObjects.PDV;

namespace PDV.Test.UI.ADMIN.TestCase.CN_02_Item.CN_02._02___Modificadores
{
    [TestClass]
    public class Tc_Modificadores
    {
        private UrlPDV Url;
        private PoLogin_PDV Login;
        private Po_Menus Menu;
        public Tc_Modificadores()
        {
            IWebDriver driver = new ChromeDriver();
            Url = new UrlPDV(driver);
            Login = new PoLogin_PDV(driver);
            Menu = new Po_Menus(driver);

        }

        [TestMethod]

        public void AdicionarModificador()
        {
            Url.AdminTST();
            Login.Admin();
            Menu.Modificadores();

        }
    }
}
