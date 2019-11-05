using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.CommonMethods.Utils;
using POS.Interactions;
using System;


namespace POS.TestCase.Rotinas_de_Venda._01._Venda_Simples
{
    [TestFixture]
    public class Tc_VendasSimples
    {
        HomePageTHExPOS HP;
        IntLogin Login;
        IntCommon IntCommon;
        IntTelaPrincipal TP;
        IntTelaDeLancamentos TL;
        IntTelaDePagamento PG;
        ValidaMsg Msg;


        public Tc_VendasSimples()
        {
            IWebDriver driver = new ChromeDriver();

            HP = new HomePageTHExPOS(driver);
            Login = new IntLogin(driver);
            IntCommon = new IntCommon(driver);
            TP = new IntTelaPrincipal(driver);
            TL = new IntTelaDeLancamentos(driver);
            PG = new IntTelaDePagamento(driver);
            Msg = new ValidaMsg(driver);
        } //Construtor

        [Test]
        public void CN001_Venda_1UN_Item()
        {
            HP.PosTST();
            Login.LoginPOS();
            IntCommon.PesqEmpPDV("R");

            //for (int i = 0; i < 5; i++)
            //{
            TP.Pesquisar("Mesa 1");
            TP.AbrirMesa();
            TL.PesquisarProd("Água mineral", " 4,50");
            TL.LancarProd_1UN();
            TL.ValidarSubtotal("R$ 4,50");
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.Confirmar();
            Msg.ValidarMsg("Conta paga com sucesso");

            //}
        }

        [Test]
        public void CN002_Venda_2UN_Item()
        {
            HP.PosTST();
            Login.LoginPOS();
            IntCommon.PesqEmpPDV("R");            
            TP.Pesquisar("Mesa 1");
            TP.AbrirMesa();
            TL.PesquisarProd("Água mineral", " 4,50");
            TL.LancarProd_2UN();
            TL.ValidarSubtotal("R$ 9,00");
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.Confirmar();
            Msg.ValidarMsg("Conta paga com sucesso");            
        }

        [Test]
        public void CN003_Venda_3_Itens_Diferentes()
        {
            HP.PosTST();
            Login.LoginPOS();
            IntCommon.PesqEmpPDV("R");
            TP.Pesquisar("Mesa 1");
            TP.AbrirMesa();
            TL.PesquisarProd("Água mineral", " 4,50");
            TL.LancarProd_1UN();
            TL.PesquisarProd("Coca Cola", " 3,50");
            TL.LancarProd_1UN();
            TL.PesquisarProd("Espaguete", " 1,00");
            TL.LancarProd_1UN();
            TL.ValidarSubtotal("R$ 9,00");
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.Confirmar();
            Msg.ValidarMsg("Conta paga com sucesso");
        }
    }

}

