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
            TP.Pesquisar("Mesa 1");
            TP.AbrirMesa();
            TL.PesquisarProd("Água mineral", " 4,50");
            TL.LancarProd_1UN();
            TL.ValidarTotalProd(" 4,50");
            TL.ValidarSubtotal("R$ 4,50");
            TL.ValidarTxServico("R$ 0,45"); //10% de taxa
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.ValidarTotaDalVenda("R$ 4,95");
            PG.Confirmar();
            Msg.ValidarMsg("Conta paga com sucesso");

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
            TL.ValidarTotalProd(" 9,00");
            TL.ValidarSubtotal("R$ 9,00");
            TL.ValidarTxServico("R$ 0,90"); //10% de taxa            
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.ValidarTotaDalVenda("R$ 9,90");
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
            TL.ValidarTxServico("R$ 0,90"); //10% de taxa            
            TL.EnviarPedido();
            TL.BtnPagamento();
            PG.Dinheiro();
            PG.ValidarTotaDalVenda("R$ 9,90");
            PG.Confirmar();
            Msg.ValidarMsg("Conta paga com sucesso");
        }
    }

}

