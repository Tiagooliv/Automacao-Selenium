using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;


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

        public void Menu (By locator)
        {
            Wait.LocateElementAndClick((locator));                 
        }

        public void Item ()
        {
            Menu(By.XPath("//thf-menu-item/div/div[1]/span"));
        }

        public void GruposDeProdutos ()
        {
            Item();
            Menu(By.XPath("//div/div[2]/div[3]/thf-menu-item/a")); //Grupo de Produtos
            driver.Navigate().Refresh();
        }

        
    }
}
