using NUnit.Framework;
using OpenQA.Selenium;
using PDV.Test.UI._0._Login;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

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
            //driver.FindElement(By.XPath(email)).SendKeys("aut@totvs.com.br");//Empresa ESTAB. AUTOMATIZADO
            driver.FindElement(By.XPath(email)).SendKeys("teste@totvs.com.br");//Empresa ESQUAD PDV/SA
            driver.FindElement(By.XPath(senha)).SendKeys("1234");
            driver.FindElement(By.XPath(BtnEntrar)).Click();
            Thread.Sleep(3000);

            //Valida título da página

            //Wait.LocateElement(By.ClassName(tituloPg));
            //var title = driver.FindElement(By.ClassName(tituloPg)).Text;
            //Assert.AreEqual("Estabelecimentos", title);      

        }

        public void Teardown()
        {
            driver.Quit();
        }


    }

}
