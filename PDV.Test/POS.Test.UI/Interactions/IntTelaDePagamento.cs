using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using POS.PageObjects;
using System.Threading;
using System.Windows.Forms;

namespace POS.Interactions
{
    public class IntTelaDePagamento : Po_TelaDePagamento
    {
        IWebDriver driver;
        WaitElement Wait;
        public IntTelaDePagamento(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void Dinheiro()
        {
            Wait.LocateElementAndClick(By.Id(FpDinheiro));
            //Wait.LocateElementAndClick(By.Id(FpDinheiro2));
        }

        public void ValidarTotaDalVenda(string ValorAserPago)
        {
            var totvenda = driver.FindElement(By.XPath(totalVenda)).Text;
            if (totvenda != ValorAserPago)
            {
                Assert.Fail(" VALOR A SER PAGO ESPERADO: " + ValorAserPago + " \n VALOR CALCULADO: " + totvenda);
            }
        }

        public void Confirmar()
        {
            Wait.LocateElementAndClick(By.XPath(btnConfirmarPG));

            //var loading = driver.FindElement(By.ClassName(load));

            //while (loading.Displayed)
            //{
            //    Thread.Sleep(8000);
            //}

            Thread.Sleep(12000);
            SendKeys.SendWait("{Esc}");
            //SendKeys.SendWait("{Enter}");
        }
    }
}
