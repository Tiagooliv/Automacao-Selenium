using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI._2._Interactions;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class IntModificadores : Po_Modificadores
    {
        private IWebDriver driver;
        WaitElement Wait;
        ValidarSwitch Sw;
        Select_Element Select;

        public IntModificadores(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidarSwitch(driver);
            Select = new Select_Element(driver);
        }

        public void BtnAdicionarModificador()
        {
            Thread.Sleep(1000);
            Wait.LocateElementAndClick(By.XPath(btnAdicionarMod));

            var text = driver.FindElement(By.ClassName(TituloModal)).Text;
            Assert.AreEqual("Novo modificador",text);
        }

        public void DadosDoModificador(string NomeMod, string QtdMin, string QtdMax, string UnMed)
        {
            driver.FindElement(By.ClassName(nomeMod)).SendKeys(NomeMod);
            driver.FindElement(By.XPath(qtdMin)).SendKeys(QtdMin);
            driver.FindElement(By.XPath(qtdMax)).SendKeys(QtdMax);
            Wait.LocateElement(By.ClassName(unMed));
            Select.ByText(By.ClassName(unMed), UnMed);
        }

        public void Modificador(string ItemTipo, string Descricao, string Preco)
        {
            driver.FindElement(By.XPath(itemTipo)).SendKeys(ItemTipo);
            driver.FindElement(By.XPath(itemTipo)).SendKeys(Keys.Tab);

            driver.FindElement(By.XPath(descricao)).SendKeys(Descricao);
            driver.FindElement(By.XPath(descricao)).SendKeys(Keys.Tab);

            driver.FindElement(By.XPath(preco)).SendKeys(Preco);
            
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath(btnSalvar)).Click();
            Wait.LocateElement(By.XPath(Msg));//Aguarda mensagem na tela "Cadastro com sucesso"

            // Valida a mensagem 
            var text = driver.FindElement(By.XPath(Msg)).Text;
            Assert.AreEqual("Modificador cadastrado com sucesso.", text);

            Thread.Sleep(3000);
            driver.FindElement(By.XPath(Msg)).Click();
        }

        #region Antiga validação 
        //public void ValidarCadastro(string NomeMod)
        //{
        //    //Pesquisa modificador cadastrado
        //    driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(NomeMod);

        //    //Guarda o primeiro resultado da lista
        //    var nomemod = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

        //    //Compara cadastro x resultado pesquisa
        //    if (nomemod != NomeMod) 
        //    {
        //        Assert.Fail("Falha no cadastro, grupo  " + NomeMod + "   não encontrado.");
        //    }

        //    //Verifica se o componente switch está ativo
        //    Sw.SwitchAtivo(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div"), "Class",
        //   "thf-switch-container thf-clickable thf-switch-container-off", "O NOVO MODIFICADOR está INATIVO");

        //    Thread.Sleep(3000);                     
        //}
        #endregion

    }
}
