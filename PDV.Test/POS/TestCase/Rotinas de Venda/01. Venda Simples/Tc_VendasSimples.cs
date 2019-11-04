﻿using NUnit.Framework;
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
        ValidarMsg Msg;


        public Tc_VendasSimples()
        {
            IWebDriver driver = new ChromeDriver();

            HP = new HomePageTHExPOS(driver);
            Login = new IntLogin(driver);
            IntCommon = new IntCommon(driver);
            TP = new IntTelaPrincipal(driver);
            TL = new IntTelaDeLancamentos(driver);
            PG = new IntTelaDePagamento(driver);
            Msg = new ValidarMsg(driver);
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
                TL.LancarItem("Água mineral");
                TL.EnviarPedido();
                TL.BtnPagamento();
                PG.Dinheiro();
                PG.Confirmar();
                Msg.ValidaMsg("Conta paga com sucesso");
            //}
        }



    }

}
