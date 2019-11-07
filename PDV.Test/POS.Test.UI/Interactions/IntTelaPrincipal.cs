using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using POS.PageObjects;
using System.Threading;


namespace POS.Interactions
{
    public class IntTelaPrincipal : Po_TelaPrincipal
    {
        IWebDriver driver;
        WaitElement Wait;
        public IntTelaPrincipal(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void Pesquisar(string Text)
        {
            Thread.Sleep(500);
            driver.FindElement(By.XPath(Pesq_Mesa_Uh_Cc)).SendKeys(Text);
            Thread.Sleep(1500);
        }

        public void AbrirMesa()
        {
            Wait.LocateElementAndClick(By.ClassName(Mesa1));
            Thread.Sleep(1000);
        }

    }

}
