using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using POS.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POS.Interactions
{
    public class IntTelaDeLancamentos : Po_TelaDeLancamentos
    {
        IWebDriver driver;
        WaitElement Wait;
        public IntTelaDeLancamentos(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void LancarItem(string Prod)
        {
            var prod = driver.FindElement(By.ClassName(pesqProd));
            prod.SendKeys(Prod);
            Thread.Sleep(500);
            prod.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            Wait.LocateElementAndClick(By.XPath(CliqueItem));
        }

        public void EnviarPedido()
        {
            Wait.LocateElementAndClick(By.XPath(btnEnviarPed));
            Thread.Sleep(2000);
        }

        public void BtnPagamento()
        {
            Wait.LocateElementAndClick(By.XPath(btnPagamento));

        }




    }
}
