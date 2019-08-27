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

        public void Inicio()
        {
            Wait.LocateElementAndClick(By.XPath("//div[1]/thf-menu-item/a/div/div"));
            //Thread.Sleep(5000);
            //driver.Close();
        }

        public void Item()
        {
            Wait.LocateElementAndClick(By.XPath("//thf-menu-item/div/div[1]/span"));
        }

        public void Produtos()
        {
            Item();            
            Wait.LocateElementAndClick(By.XPath("//div[2]/div[1]/thf-menu-item/a/div/div"));//Produtos
            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "PRODUTOS");
        }

        public void Modificadores()
        {
            Item();            
            Wait.LocateElementAndClick(By.XPath("//div[2]/div[2]/thf-menu-item/a/div/div"));//Modificadores
            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "MODIFICADORES");
        }

        public void GruposDeProdutos()
        {
            Item();           
            Wait.LocateElementAndClick(By.XPath("//div/div[2]/div[3]/thf-menu-item/a")); //Grupo de Produtos
            ValidarTituloLista(By.XPath("//div[1]/button/span[2]"), "GRUPOS");

            //driver.Navigate().Refresh();
        }

        public void PontoDeVenda()
        {
            Wait.LocateElementAndClick(By.XPath("//div[3]/thf-menu-item/div/div[1]/div"));
        }

        public void PDV()
        {
            PontoDeVenda();            
            Wait.LocateElementAndClick(By.XPath("//div[3]/thf-menu-item/div/div[2]/div[1]/thf-menu-item/a/div/div"));//PDV
            ValidarTituloLista(By.XPath("//div/ni-collapsible-widget/div/div[1]/button/span[2]"), "PONTOS DE VENDA");
        }

        

      


       




    }
}
