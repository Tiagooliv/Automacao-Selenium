﻿using NUnit.Framework;
using OpenQA.Selenium;
using PDV.Test.UI._0._Login;
using PDV.Test.UI.POS.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PDV.Test.UI._2._Interactions
{
   public class IntLogin: Po_Login
    {
        IWebDriver driver;
        WaitElement Wait;

        public IntLogin(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void LoginPOS ()
        {
            driver.FindElement(By.XPath(email)).SendKeys("teste@totvs.com.br");
            driver.FindElement(By.XPath(senha)).SendKeys("1234");
            driver.FindElement(By.XPath(BtnEntrar)).Click();
            Thread.Sleep(4000);

            //Valida título da página

            Wait.LocateElement(By.ClassName(tituloPg));
            var title = driver.FindElement(By.ClassName(tituloPg)).Text;
            Assert.AreEqual("Estabelecimentos", title);

            // Seleção de estabelecimento (Criar Classes separada)

            driver.FindElement(By.XPath("//div/div[2]/input")).SendKeys("SQUAD PDV");
            driver.FindElement(By.ClassName("initials-header")).Click();
            Thread.Sleep(2000);

        }


    }

}