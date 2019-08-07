using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Produto
    {
        public IWebDriver driver;
        public WaitElement Wait;

        public Po_Produto(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
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

            
            var tab = driver.FindElement(By.XPath("//div/div[2]/div/div[1]/thf-input[2]/thf-field-container/div/div[2]/input"));
            tab.SendKeys(Keys.Tab);

            var clique = driver.FindElement(By.XPath("//div/div[2]/div/div[1]/thf-multiselect/thf-field-container/div/div[2]/input"));
            clique.SendKeys(Keys.ArrowDown);

            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//div/div[2]/div/div[1]/thf-multiselect/thf-field-container/div/div[2]/input"));
            clique.SendKeys(Keys.ArrowDown);

            Thread.Sleep(1000);

            var grupoproduto = driver.FindElement(By.XPath("//div/thf-multiselect-search/div/input"));
            grupoproduto.SendKeys(GrupoProduto);

            driver.FindElement(By.XPath("//div/thf-multiselect-dropdown/div/ul/thf-multiselect-item/li/a")).Click();

            var tab1 = driver.FindElement(By.XPath("//div/thf-multiselect-search/div/input"));
            tab1.SendKeys(Keys.Tab);

            var unimedida = driver.FindElement(By.XPath("//div/div[1]/thf-select/thf-field-container/div/select"));
            unimedida.SendKeys(Keys.ArrowDown);

            driver.FindElement(By.XPath("//div/div[1]/thf-select/thf-field-container/div/select"));
            unimedida.SendKeys(Keys.ArrowDown);

            driver.FindElement(By.XPath("//div/div[1]/thf-select/thf-field-container/div/select"));
            unimedida.SendKeys(UnidMedida);

            driver.FindElement(By.XPath("//div/div[1]/thf-select/thf-field-container/div/select"));
            unimedida.SendKeys(Keys.Enter);


            var prunitario = driver.FindElement(By.XPath("//div/div[2]/thf-decimal/thf-field-container/div/div[2]/input"));
            prunitario.SendKeys(PrUnitario);



        }

        public void Detalhes(string Modificadores)
        {

            driver.FindElement(By.XPath("//div[2]/div/div/div[2]/div/thf-multiselect/thf-field-container/div/div[2]/div[1]/span")).Click();

            var modificadores = driver.FindElement(By.XPath("//div[2]/div/thf-multiselect/thf-field-container/div/thf-multiselect-dropdown/div/thf-multiselect-search/div/input"));
            modificadores.SendKeys(Modificadores);

            driver.FindElement(By.XPath("//div/div[2]/div/div/div[2]/div/thf-multiselect/thf-field-container/div/thf-multiselect-dropdown/div/ul/thf-multiselect-item/li/a/label")).Click();

            var tab = driver.FindElement(By.XPath("//div/div[2]/div/thf-multiselect/thf-field-container/div/div[2]/input"));
            tab.SendKeys(Keys.Tab);
            
        }

        public void Fiscais()
        {

            //driver.FindElement(By.XPath("//div[4]/ni-collapsible-widget/div/div[1]/button/span[2]")).Click();

            driver.FindElement(By.XPath("//div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/div/div/span")).Click();

            driver.FindElement(By.XPath("//div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/ul/li/div/span")).Click();

            //driver.FindElement(By.XPath("//div/div/div/div/pos-item-form/form/div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/ul/li/div/span")).Click();

        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath("//div[6]/thf-button[2]/button/span")).Click();//Salvar
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div")); //Aguarda mensagem na tela

            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div")).Text;
            Assert.AreEqual("Produto cadastrado com sucesso.", Msg); // Valida a mensagem                         

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

        }
    }
}
