using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Produto
    {
        public IWebDriver driver;
        public WaitElement Wait;
        private ValidateSwitch Sw;

        public Po_Produto(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidateSwitch(driver);
        }

        public void BtnAdicionarProduto()
        {
            Wait.LocateElementAndClick(By.XPath("//div/div[1]/div/thf-button/button"));
        }

        public void DadosProduto(string NomeProduto, string CodInterno, string GrupoProduto, string UnidMedida,  string PrUnitario)
        {

            var nomeproduto = driver.FindElement(By.ClassName("thf-input"));
            nomeproduto.SendKeys(NomeProduto);

            var codinterno = driver.FindElement(By.XPath("//div/div[2]/div/div[1]/thf-input[2]/thf-field-container/div/div[2]/input"));
            codinterno.SendKeys(CodInterno);
            codinterno.SendKeys(Keys.Tab);

            var clique = driver.FindElement(By.XPath("//div/div[2]/div/div[1]/thf-multiselect/thf-field-container/div/div[2]/input"));
            clique.SendKeys(Keys.ArrowDown);
            clique.SendKeys(Keys.ArrowDown);

            Thread.Sleep(1000);

            var grupoproduto = driver.FindElement(By.XPath("//div/thf-multiselect-search/div/input"));
            grupoproduto.SendKeys(GrupoProduto);

            driver.FindElement(By.XPath("//div/thf-multiselect-dropdown/div/ul/thf-multiselect-item/li/a")).Click();

            grupoproduto.SendKeys(Keys.Tab);

            var unimedida = driver.FindElement(By.XPath("//div/div[1]/thf-select/thf-field-container/div/select"));
            unimedida.SendKeys(Keys.ArrowDown);
            unimedida.SendKeys(Keys.ArrowDown);
            unimedida.SendKeys(UnidMedida);
            unimedida.SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//div/div[2]/thf-decimal/thf-field-container/div/div[2]/input")).SendKeys(PrUnitario);
            
        }

        public void Detalhes(string Modificadores)
        {

            driver.FindElement(By.XPath("//div[2]/div/div/div[2]/div/thf-multiselect/thf-field-container/div/div[2]/div[1]/span")).Click();

            var modificadores = driver.FindElement(By.XPath("//div[2]/div/thf-multiselect/thf-field-container/div/thf-multiselect-dropdown/div/thf-multiselect-search/div/input"));

            modificadores.SendKeys(Modificadores);
            modificadores.Click();

            var tab = driver.FindElement(By.XPath("//div/div[2]/div/thf-multiselect/thf-field-container/div/div[2]/input"));
            tab.SendKeys(Keys.Tab);
            
        }

        public void Fiscais()
        {
            driver.FindElement(By.XPath("//div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/div/div/span")).Click();
            driver.FindElement(By.XPath("//div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/ul/li/div/span")).Click();     
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath("//div[6]/thf-button[2]/button/span")).Click();//Salvar
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div")); //Aguarda mensagem na tela

            // Valida a mensagem  
            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div")).Text;
            Assert.AreEqual("Produto cadastrado com sucesso.", Msg);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/thf-toaster/div")).Click();

        }

        public void ValidarCadastro(string NomeProduto)
        {
            var Pesquisaproduto = driver.FindElement(By.XPath("//div/div[1]/thf-input/thf-field-container/div/div[2]/input"));
            Pesquisaproduto.SendKeys(NomeProduto);

            var nomeproduto = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

            if (nomeproduto != NomeProduto)
            {
                Assert.Fail("Falha no cadastro do produto  " + NomeProduto + "   não encontrado.");
            }

            //Verifica se o componente switch está ativo
            Sw.SwitchAtivo(By.XPath("//tr/td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div/div"), "Class",
           "thf-switch-button thf-switch-button-off", "O NOVO PRODUTO está INATIVO");

            Thread.Sleep(3000);

        }
    }
}
