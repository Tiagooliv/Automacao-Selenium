using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects.Menus
{
   public class Po_Menus
    {
        private IWebDriver driver;
        private WaitElement Wait;

        public Po_Menus(IWebDriver driver)
        {
            this.driver = driver;    
            Wait = new WaitElement(driver);
        }

        public void ValidarTituloLista(By locator, string TituloLista)
        {
            Wait.LocateElement(locator);
            var titulo = driver.FindElement(locator).Text;
            Assert.AreEqual(TituloLista, titulo);
        }
        public void Menu (By locator)
        {
            Wait.LocateElementAndClick((locator));                 
        }

        public void Item ()
        {
            Menu(By.XPath("//thf-menu-item/div/div[1]/span"));
        }

        public void Produtos()
        {
            Item();

            //Produtos
            Menu(By.XPath("//div[2]/div[1]/thf-menu-item/a/div/div"));

            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "PRODUTOS");

        }

        public void Modificadores()
        {
            Item();

            //Modificadores
            Menu(By.XPath("//div[2]/div[2]/thf-menu-item/a/div/div"));

            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "MODIFICADORES");
        }

        public void GruposDeProdutos ()
        {
            Item();

            //Grupo de Produtos
            Menu(By.XPath("//div/div[2]/div[3]/thf-menu-item/a"));

            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "GRUPOS");

            //driver.Navigate().Refresh();
        }

     

        
    }
}
