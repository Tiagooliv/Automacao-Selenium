using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;
using PDV.Test.UI.ADMIN.PageObjects;

namespace PDV.Test.UI.Interactions
{
    public class IntProduto : Po_Produto
    {
        public IWebDriver driver;
        WaitElement Wait;
        ValidarSwitch Sw;
        Select_Element Select;

        public IntProduto(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidarSwitch(driver);
            Select = new Select_Element(driver);
        }

        public void BtnAdicionarProduto()
        {
            Wait.LocateElementAndClick(By.XPath(btnAdicionarProduto));
        }

        public void DadosProduto(string NomeProduto, string CodInterno, string GrupoProduto, string UnidMedida, string PrUnitario)
        {
            driver.FindElement(By.ClassName(nomeproduto)).SendKeys(NomeProduto);
           
            driver.FindElement(By.XPath(codinterno)).SendKeys(CodInterno);
            driver.FindElement(By.XPath(codinterno)).SendKeys(Keys.Tab);

            driver.FindElement(By.XPath(grupo)).Click();
            driver.FindElement(By.XPath(grupo)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);

            driver.FindElement(By.XPath(grupoproduto)).SendKeys(GrupoProduto);
            driver.FindElement(By.XPath(Clickgrupoproduto)).Click();
            driver.FindElement(By.XPath(grupoproduto)).SendKeys(Keys.Tab);

            //Select.ByText(By.ClassName("thf-select"),UnidMedida);
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.XPath(unimedida)).SendKeys(UnidMedida);
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath(prUnitario)).SendKeys(PrUnitario);
        }

        public void Detalhes(string Modificadores)
        {
            driver.FindElement(By.XPath(cliquemodificadores)).Click();

            driver.FindElement(By.XPath(modificadores)).SendKeys(Modificadores);

            driver.FindElement(By.XPath(cliquemodifdetalhes)).Click();

            driver.FindElement(By.XPath(modificadores)).SendKeys(Keys.Tab);

        }

        public void Fiscais()
        {
            driver.FindElement(By.XPath(cliquefiscais)).Click();

            driver.FindElement(By.XPath(cliquefiscaisSelect)).Click();
            
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath(salvar)).Click();//Salvar
            Wait.LocateElement(By.XPath(msg)); //Aguarda mensagem na tela

            // Valida a mensagem  
            driver.FindElement(By.XPath(msg)).Text.ToString();
            Assert.AreEqual("Produto cadastrado com sucesso.", msg);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(msg)).Click();

        }

        public void BtnEditar()
        {
            driver.FindElement(By.XPath(trespontos)).Click();

            driver.FindElement(By.XPath(editar)).Click();

        }

        public void EditarProduto(string NomeProduto, string CodInterno, string GrupoProduto, string UnidMedida, string PrUnitario)
        {
            driver.FindElement(By.XPath(nomeproduto)).Clear();
            driver.FindElement(By.XPath(nomeproduto)).SendKeys(NomeProduto);

            driver.FindElement(By.XPath(codinterno)).Clear();
            driver.FindElement(By.XPath(codinterno)).SendKeys(CodInterno);
            driver.FindElement(By.XPath(codinterno)).SendKeys(Keys.Tab);

            driver.FindElement(By.XPath(grupo)).Clear();
            driver.FindElement(By.XPath(grupo)).Click();
            driver.FindElement(By.XPath(grupo)).SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);

            driver.FindElement(By.XPath(grupoproduto)).Clear();
            driver.FindElement(By.XPath(grupoproduto)).SendKeys(GrupoProduto);
            driver.FindElement(By.XPath(Clickgrupoproduto)).Click();
            driver.FindElement(By.XPath(grupoproduto)).SendKeys(Keys.Tab);

            //Select.ByText(By.ClassName("thf-select"),UnidMedida);
            driver.FindElement(By.XPath(unimedida)).Clear();
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.XPath(unimedida)).SendKeys(UnidMedida);
            driver.FindElement(By.XPath(unimedida)).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath(PrUnitario)).Clear();
            driver.FindElement(By.XPath(PrUnitario)).SendKeys(PrUnitario);
        }

        #region Validação antiga
        //public void ValidarCadastro(string NomeProduto)
        //{
        //    var Pesquisaproduto = driver.FindElement(By.XPath("//div/div[1]/thf-input/thf-field-container/div/div[2]/input"));
        //    Pesquisaproduto.SendKeys(NomeProduto);

        //    var nomeproduto = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

        //    if (nomeproduto != NomeProduto)
        //    {
        //        Assert.Fail("Falha no cadastro do produto  " + NomeProduto + "   não encontrado.");
        //    }

        //    //Verifica se o componente switch está ativo
        //    Sw.SwitchAtivo(By.XPath("//tr/td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div/div"), "Class",
        //   "thf-switch-button thf-switch-button-off", "O NOVO PRODUTO está INATIVO");

        //    Thread.Sleep(3000);

        //}
        #endregion
    }
}
