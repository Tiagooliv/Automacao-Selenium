using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Modificadores
    {
        private IWebDriver driver;
        private WaitElement Wait;
        private Keyboard Key;

        public Po_Modificadores(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Key = new Keyboard(driver); 
        }

        public void BtnAdicionarModificador()
        {
            Wait.LocateElementAndClick(By.XPath("//div[1]/div/thf-button/button/span"));          
        }

        public void DadosDoModificador(string NomeMod, string QtdMin, string QtdMax, string UnMed)
        {
            Wait.LocateElement(By.ClassName("thf-font-subtitle"));
            var Titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo modificador", Titulo); //Valida Titulo da Página

            var nomeMod = driver.FindElement(By.ClassName("thf-input"));
            var qtdmin = driver.FindElement(By.XPath("//thf-decimal[1]/thf-field-container/div/div[2]/input"));
            var qtdmax = driver.FindElement(By.XPath("//thf-decimal[2]/thf-field-container/div/div[2]/input"));
            SelectElement unmed = new SelectElement(driver.FindElement(By.ClassName("thf-select")));

            nomeMod.SendKeys(NomeMod);
            qtdmin.SendKeys(QtdMin);
            qtdmax.SendKeys(QtdMax);
            unmed.SelectByText(UnMed);              
        }

        public void Modificador(string ItemTipo, string descricao,string Preco)
        {
          driver.FindElement(By.XPath("//div[2]/thf-combo/thf-field-container/div/div[2]/input")).SendKeys(ItemTipo);
          Key.Tab(By.XPath("//div[2]/thf-combo/thf-field-container/div/div[2]/input"));

          driver.FindElement(By.XPath("//div[3]/thf-input/thf-field-container/div/div[2]/input")).SendKeys(descricao);
          Key.Tab(By.XPath("//div[3]/thf-input/thf-field-container/div/div[2]/input"));

          driver.FindElement(By.XPath("//div[5]/thf-decimal/thf-field-container/div/div[2]/input")).SendKeys(Preco);        
            
        }

        public void BtnSalvar ()
        {
            driver.FindElement(By.XPath("//thf-button[2]/button/span")).Click();
        }

    }
}
