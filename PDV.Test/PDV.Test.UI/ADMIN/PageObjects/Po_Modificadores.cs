using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Modificadores
    {
        private IWebDriver driver;
        private WaitElement Wait;
        private ValidateSwitch Sw;

        public Po_Modificadores(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidateSwitch(driver);
        }

        public void BtnAdicionarModificador()
        {
            Thread.Sleep(1000);
            Wait.LocateElementAndClick(By.XPath("//div[1]/div/thf-button/button"));

            var titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo modificador", titulo);
        }

        public void DadosDoModificador(string NomeMod, string QtdMin, string QtdMax, string UnMed)
        {
            driver.FindElement(By.ClassName("thf-input")).SendKeys(NomeMod);
            driver.FindElement(By.XPath("//thf-decimal[1]/thf-field-container/div/div[2]/input")).SendKeys(QtdMin);
            driver.FindElement(By.XPath("//thf-decimal[2]/thf-field-container/div/div[2]/input")).SendKeys(QtdMax);

            Wait.LocateElement(By.ClassName("thf-select"));
            SelectElement unmed = new SelectElement(driver.FindElement(By.ClassName("thf-select")));
            unmed.SelectByText(UnMed);
        }

        public void Modificador(string ItemTipo, string Descricao, string Preco)
        {
            var itemtipo = driver.FindElement(By.XPath("//div[2]/thf-combo/thf-field-container/div/div[2]/input"));
            var descricao = driver.FindElement(By.XPath("//div[3]/thf-input/thf-field-container/div/div[2]/input"));

            itemtipo.SendKeys(ItemTipo);
            itemtipo.SendKeys(Keys.Tab);
            descricao.SendKeys(Descricao);
            descricao.SendKeys(Keys.Tab);

            driver.FindElement(By.XPath("//div[5]/thf-decimal/thf-field-container/div/div[2]/input")).SendKeys(Preco);
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath("//thf-button[2]/button/span")).Click();
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div/div"));//Aguarda mensagem na tela "Cadastro com sucesso"

            // Valida a mensagem 
            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Text;
            Assert.AreEqual("Modificador cadastrado com sucesso.", Msg);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Click();
        }

        public void ValidarCadastro(string NomeMod)
        {
            //Pesquisa modificador cadastrado
            driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(NomeMod);

            //Guarda o primeiro resultado da lista
            var nomemod = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

            //Compara cadastro x resultado pesquisa
            if (nomemod != NomeMod) 
            {
                Assert.Fail("Falha no cadastro, grupo  " + NomeMod + "   não encontrado.");
            }

            //Verifica se o componente switch está ativo

            Sw.SwitchAtivo(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div"), "Class",
           "thf-switch-container thf-clickable thf-switch-container-off", "O NOVO MODIFICADOR está INATIVO");

            Thread.Sleep(3000);

            #region Antiga validação 
            //var Switch = driver.FindElement(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div")).GetAttribute("Class");

            //if (Switch.Equals("thf-switch-container thf-clickable thf-switch-container-off"))
            //{
            //    Assert.Fail("Modificador Inativo");
            //}
            #endregion

            //driver.Close();
        }

    }
}
