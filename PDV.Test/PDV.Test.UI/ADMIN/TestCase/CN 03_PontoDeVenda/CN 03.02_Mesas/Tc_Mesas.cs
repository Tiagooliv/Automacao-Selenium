using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.ADMIN.PageObjects.Menus;
using PDV.Test.UI.CommonMethods.Utils;

namespace PDV.Test.UI.ADMIN.TestCase.CN_03_PontoDeVenda.CN_03._02_Mesas
{
    [TestFixture]
    public class Tc_Mesas
    {       
        HomePageTHExPOS HP;
        IntLogin Login;
        Po_Menus Menu;
        IntMesas M;
        ValidarCadastro Vc;
        
        public Tc_Mesas()
        {
            IWebDriver driver = new ChromeDriver();
            HP = new HomePageTHExPOS(driver);
            Login = new IntLogin(driver);
            Menu = new Po_Menus(driver);
            M = new IntMesas(driver);
            Vc = new ValidarCadastro(driver);
        }

        [Test]
        public void AdicionarMesa()
        {
            HP.AdminTST();
            Login.LoginPOS();
            Menu.Mesas("PDV - Aut");
            M.BtnAdicionarMesas();
            M.DadosMesa("1", "4"/*, "Praça de alimentação"*/);
            M.BtnSalvar("Mesa cadastrada com sucesso.");
            Vc.ValidaCadastro("Mesa 1");
        }

        [Test]
        public void EditarMesa()
        {
            HP.AdminTST();
            Login.LoginPOS();
            Menu.Mesas("PDV - Aut");
            M.Editar();
            M.DadosMesa("2","");
            M.BtnSalvar("Mesa cadastrada com sucesso.");
            Vc.ValidaCadastro("Mesa 2");          
        }

        [Test]
        public void ExcluirMesa()
        {
            HP.AdminTST();
            Login.LoginPOS();
            Menu.Mesas("PDV - Aut");
            Vc.PesqCad("Mesa 2");
            M.Excluir("Mesa removida com sucesso.");
        }


    }
}
