using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

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
          Thread.Sleep(1000);
          driver.FindElement(By.XPath("//div[1]/div/thf-button/button")).Click();
        }

        public void DadosDoModificador(string NomeMod, string QtdMin, string QtdMax, string UnMed)
        {
            Wait.LocateElement(By.ClassName("thf-font-subtitle"));
            var Titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo modificador", Titulo); //Valida Titulo da Página

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

            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Text;
            Assert.AreEqual("Modificador cadastrado com sucesso.", Msg); // Valida a mensagem 
        }

        public void ValidarCadastro(string NomeMod)
        {
            driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(NomeMod);//Pesquisa modificador cadastrado
            
            var nomemod = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;//Guarda o primeiro resultado
            if (nomemod != NomeMod) //Compara cadastro x resultado pesquisa
            {
                Assert.Fail("Falha no cadastro, grupo  " + NomeMod + "   não encontrado.");
            }

            var CadAtivo = driver.FindElement(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div")).GetAttribute("Class");
            if (CadAtivo.Equals("thf-switch-container thf-clickable thf-switch-container-off"))
            {
                Assert.Fail("Modificador Inativo");
            }
        }

    }
}
