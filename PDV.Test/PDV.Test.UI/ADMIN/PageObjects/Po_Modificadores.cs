using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Modificadores
    {
        private IWebDriver driver;
        private WaitElement Wait;
        public Po_Modificadores(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void BtnAdicionarModificador()
        {
            Wait.LocateElementAndClick(By.ClassName("thf-button-label"));
        }

        public void DadosDoModificador(string NomeMod, string QtdMin, string QtdMax, string UnMed)
        {
            Wait.LocateElement(By.ClassName("thf-font-subtitle"));
            var Titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo modificador", Titulo); //Valida Titulo da Página

            var nomeMod = driver.FindElement(By.Name("thf-font-subtitle"));
            var qtdmin = driver.FindElement(By.Name("amountMinimum"));
            var qtdmax = driver.FindElement(By.Name("amountMaximun"));
            var unmed = driver.FindElement(By.ClassName("thf-select"));

            nomeMod.SendKeys(NomeMod);
            qtdmin.SendKeys(QtdMin);
            qtdmax.SendKeys(QtdMax);
            unmed.SendKeys(UnMed);                     
        }

    }
}
