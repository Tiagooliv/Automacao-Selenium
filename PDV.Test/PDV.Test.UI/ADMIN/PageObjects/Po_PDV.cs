using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_PDV
    {
        private IWebDriver driver;
        private WaitElement Wait;
        private Select_Element Select;

        public Po_PDV(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Select = new Select_Element(driver);
        }

        public void BtnAdicionarPDV ()
        {
            Wait.LocateElementAndClick(By.ClassName("thf-button-label"));

            //Valida Titulo da Página
            var titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo PDV", titulo);
        }

        public void Dados(string NomePDV, string Estab, string País, string Idioma )
        {
            driver.FindElement(By.ClassName("thf-input")).SendKeys(NomePDV);

            //*** Estabelecimento, componente não funciona select ***

            //Select.ByText(By.XPath("//thf-select[1]/thf-field-container/div/select"), Estab);

            driver.FindElement(By.XPath("//div/thf-select[1]/thf-field-container/div/div[2]/div/div/span")).Click();
            driver.FindElement(By.XPath("//thf-field-container/div/div[2]/ul/li/div")).Click();

            Select.ByText(By.XPath("//thf-select[2]/thf-field-container/div/select"), País);
            Select.ByText(By.XPath("//thf-select[3]/thf-field-container/div/select"), Idioma);                                 
        }




    }
}
