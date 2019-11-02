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

        public void Confirmar()
        {
            Wait.LocateElementAndClick(By.XPath(btnConfirmarPG));

            //var loading = driver.FindElement(By.ClassName(load));

            //while (loading.Displayed)
            //{
            //    Thread.Sleep(8000);
            //}

            Thread.Sleep(10000);
            SendKeys.SendWait("[{Enter}");
        }
    }
}
