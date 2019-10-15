using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI._2._Interactions;

namespace PDV.Test.UI.Interactions
{
    public class IntProduto : Po_Produto
    {
        public IWebDriver driver;
        WaitElement Wait;
        ValidarSwitch Sw;
        Select_Element Select;
        ValidarMsg Msg;
        IntCommon intCommon;

        public IntProduto(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidarSwitch(driver);
            Select = new Select_Element(driver);
            Msg = new ValidarMsg(driver);
            intCommon = new IntCommon(driver);

        }

        public void BtnAdicionarProduto()
        {
            Wait.LocateElementAndClick(By.XPath(btnAdicionarProduto));
        }

        public void DadosProduto(string NomeProduto, string CodInterno, string GrupoProduto, string UnidMedida, string CodBarras,string PrUnitario)
        {
            driver.FindElement(By.XPath(nomeproduto)).SendKeys(NomeProduto);
           
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

            driver.FindElement(By.XPath(Codbarras)).SendKeys(CodBarras);

            driver.FindElement(By.XPath(prUnitario)).SendKeys(PrUnitario);
        }

        public void Detalhes(string Modificadores)
        {
            driver.FindElement(By.XPath(cliquemodificadores)).Click();
            driver.FindElement(By.XPath(modificadores)).SendKeys(Modificadores);

            driver.FindElement(By.XPath(cliquemodifdetalhes)).Click();
            driver.FindElement(By.XPath(modificadores)).SendKeys(Keys.Tab);
        }

        public void Fiscais(string NCM)
        {
            
            driver.FindElement(By.XPath(CodNCM)).SendKeys(NCM);
            Wait.LocateElementAndClick(By.XPath(CliqueNCM));
            driver.FindElement(By.XPath(CodNCM)).SendKeys(Keys.Tab);           
            
        }

        public void BtnSalvar(string msg)
        {
            driver.FindElement(By.XPath(salvar)).Click();//Salvar
            Msg.ValidaMsg(msg);
        }       

        public void Editar()
        {
            intCommon.MenuEditarList();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(nomeproduto)).Clear();

        }

        public void DuplicarProduto()
        {
            driver.FindElement(By.XPath(trespontos)).Click();

            driver.FindElement(By.XPath(duplicar)).Click();

            driver.FindElement(By.XPath(confirmar)).Click();

            Msg.ValidaMsg("Produto duplicado com sucesso");

            driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Clear();
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
