using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;


namespace PDV.Test.UI.Interactions
{
    public class IntPDV : Po_PDV
    {
        IWebDriver driver;
        WaitElement Wait;
        Select_Element Select;
        ValidarMsg Msg;
        Po_Common Poc;
        

        public IntPDV(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Select = new Select_Element(driver);
            Msg = new ValidarMsg(driver);
            Poc = new Po_Common();
        }

        public void BtnAdicionarPDV()
        {
            Wait.LocateElementAndClick(By.ClassName(btnAdicionarPDV));

            var titulo = driver.FindElement(By.ClassName(TituloModal)).Text;
            Assert.AreEqual("Novo PDV", titulo);
        }

        public void Dados(string NomePDV, string Estab, string País, string Idioma)
        {
            driver.FindElement(By.ClassName("thf-input")).SendKeys(NomePDV);

            //*** Estabelecimento, componente não funciona select ***

            //Select.ByText(By.XPath("//thf-select[1]/thf-field-container/div/select"), Estab);

            driver.FindElement(By.XPath(EstabClique1)).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath(EstabClique2)).Click();
            Select.ByText(By.XPath(país), País);
            Select.ByText(By.XPath(idioma), Idioma);
        }

        public void TaxaServico(string Tx1, string Tx2, string Tx3)
        {
            driver.FindElement(By.ClassName(btnAdicionarTx)).Click();

            driver.FindElement(By.XPath(tx1)).SendKeys(Tx1);
            driver.FindElement(By.XPath(tx2)).SendKeys(Tx2);
            driver.FindElement(By.XPath(tx3)).SendKeys(Tx3);
        }

        public void AssociarItens(string NomeProd)
        {
            //Pesquisa Item
            driver.FindElement(By.XPath(nomeProd)).SendKeys(NomeProd);

            try
            {
                //Valida resultado
                var Result = driver.FindElement(By.XPath(result)).Text.ToUpper();
                Assert.AreEqual(NomeProd.ToUpper(), Result);

                //Ativa o Switch
                driver.FindElement(By.XPath(SwitchItem)).Click();
            }

            catch (AssertFailedException) //Resultado <> da busca
            {
                Assert.Fail("ITEM " + NomeProd + "  NÃO ENCONTRADO");
            }

            catch //Nenhum item encontrado
            {
                var x = driver.FindElement(By.XPath(QuadroVazio)).Text;

                if (x != null)
                {
                    Assert.Fail("ITEM " + NomeProd + "  NÃO ENCONTRADO");
                }
            }

        }

        public void BtnSalvar(string msg)
        {
            driver.FindElement(By.ClassName(btnsalvar)).Click();
            Msg.ValidaMsg(msg);
        }

        public void Editar() 
        {
            
        }

    }
}
