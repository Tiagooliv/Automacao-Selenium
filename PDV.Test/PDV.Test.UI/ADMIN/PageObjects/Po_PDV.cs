using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System;
using System.Threading;
using Validation;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_PDV
    {
        private IWebDriver driver;
        private WaitElement Wait;
        private Select_Element Select;
        private ValidateSwitch Sw;

        public Po_PDV(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Select = new Select_Element(driver);
            Sw = new ValidateSwitch(driver);
        }

        public void BtnAdicionarPDV()
        {
            //Botão  Adicionar PDV
            Wait.LocateElementAndClick(By.ClassName("thf-button-label"));

            //Valida Titulo da Página
            var titulo = driver.FindElement(By.ClassName("thf-font-subtitle")).Text;
            Assert.AreEqual("Novo PDV", titulo);
        }

        public void Dados(string NomePDV, string Estab, string País, string Idioma)
        {
            driver.FindElement(By.ClassName("thf-input")).SendKeys(NomePDV);

            //*** Estabelecimento, componente não funciona select ***

            //Select.ByText(By.XPath("//thf-select[1]/thf-field-container/div/select"), Estab);

            driver.FindElement(By.XPath("//div/thf-select[1]/thf-field-container/div/div[2]/div/div/span")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//thf-field-container/div/div[2]/ul/li/div")).Click();

            Select.ByText(By.XPath("//thf-select[2]/thf-field-container/div/select"), País);
            Select.ByText(By.XPath("//thf-select[3]/thf-field-container/div/select"), Idioma);
        }

        public void TaxaServico(string Tx1, string Tx2, string Tx3)
        {
            //Botão Adicionar Taxa
            driver.FindElement(By.ClassName("thf-button-label")).Click();

            //Taxas
            driver.FindElement(By.XPath("//thf-decimal[1]/thf-field-container/div/div[2]/input")).SendKeys(Tx1);
            driver.FindElement(By.XPath("//thf-decimal[2]/thf-field-container/div/div[2]/input")).SendKeys(Tx2);
            driver.FindElement(By.XPath("//thf-decimal[3]/thf-field-container/div/div[2]/input")).SendKeys(Tx3);

        }

        public void AssociarItens(string NomeProd)
        {
            //Pesquisa Item
            driver.FindElement(By.XPath
            ("//ni-collapsible-widget/div/div[1]/thf-input/thf-field-container/div/div[2]/input")).SendKeys(NomeProd);

            try
            {
                //Valida resultado
                var result = driver.FindElement(By.XPath("//tbody[1]/tr/td[2]/div/span")).Text;
                Assert.AreEqual(NomeProd, result);

                //Ativa Switch
                driver.FindElement(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div/div/span")).Click();
            }
            catch
            {
                //Caso não encontre o item
                var x = driver.FindElement(By.XPath("//ni-table[1]/thf-container/div/div/div/div/div/table/tbody/tr/td/span")).Text;

                if (x!=null)
                {
                    Assert.Fail("Item não encontrado !!");
                }
            }          
        }

        public void BtnSalvar()
        {
            //Salvar
            driver.FindElement(By.ClassName("thf-button-primary")).Click();

            //Aguarda mensagem na tela "Cadastro com sucesso"
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div/div"));

            //Guarda mensagem
            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Text;

            // Valida a mensagem 
            Assert.AreEqual("Ponto de venda cadastrado com sucesso.", Msg);
        }

        public void ValidarCadastro(string NomePDV)
        {
            //Pesquisa grupo cadastrado
            driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(NomePDV);

            //Guarda o primeiro resultado da lista
            var nomepdv = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

            //Compara cadastro x resultado pesquisa
            if (nomepdv != NomePDV)
            {
                Assert.Fail("Falha no cadastro, " + NomePDV + "   NÃO ENCONTRADO.");
            }

            //Verifica se o componente switch está ativo

            Sw.SwitchAtivo(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div"), "Class",
            "thf-switch-container thf-clickable thf-switch-container-off", "O NOVO PDV está INATIVO");

            Thread.Sleep(10000);

        }
               

    }
}
