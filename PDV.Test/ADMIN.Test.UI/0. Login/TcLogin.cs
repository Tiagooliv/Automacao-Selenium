using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.CommonMethods.Utils;


namespace PDV.Test.UI.TestPlan.LG
{
    [TestFixture]
    public class TcLG_POS
    {
        
        private HomePageTHExPOS HP;
        private IntLogin Login;

        public TcLG_POS()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            Login = new IntLogin(driver);
        }

        [Test]
        public void AcessarAdmin()
        {
            HP.AdminTST();
            Login.LoginPOS();
        }

        [Test]
        public void AcessarPos()
        {
            HP.PosTST();
            Login.LoginPOS();
        } 

    }
}
