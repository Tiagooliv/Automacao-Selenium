using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_GruposDeProdutos
    {
        public IWebDriver driver;
        WaitElement Wait;
        ValidarSwitch Sw;
        ValidarCadastro Vc;
        public Po_GruposDeProdutos(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidarSwitch(driver);
            Vc = new ValidarCadastro(driver);
        }

        public void BtnAdicionarGrupo()
        {
            Wait.LocateElementAndClick(By.ClassName("thf-button-sm"));
        }

        public void DadosdoGrupo(string NomeGrupo, string GrupoFixo)
        {
            //Titulo Modal
            Wait.LocateElement(By.ClassName("thf-modal-title"));

            driver.FindElement(By.XPath("//div[2]//div[1]/div[1]/thf-input/thf-field-container/div/div[2]/input")).SendKeys(NomeGrupo);

            SelectElement grupofixo = new SelectElement(driver.FindElement(By.ClassName("thf-select")));
            grupofixo.SelectByText(GrupoFixo);
        }

        public void IconeGrupo()
        {
            // ìcone Bebida
            driver.FindElement(By.XPath("//ni-item-card[3]/div/div/div/img")).Click();
        }

        public void BtnSalvar()
        {
            //Salvar
            driver.FindElement(By.XPath("//div[3]/thf-button[2]/button")).Click();

            //Aguarda mensagem na tela "Cadastro com sucesso"
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div/div"));

            //Guarda mensagem
            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Text;

            // Valida a mensagem 
            Assert.AreEqual("Grupo criado com sucesso", Msg);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Click();
        }

        #region Antiga validação
        //public void ValidarCadastro(string NomeGrupo)
        //{
        //    //Pesquisa grupo cadastrado
        //    driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(NomeGrupo);

        //    //Guarda o primeiro resultado da lista
        //    var nomegrupo = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

        //    //Compara cadastro x resultado pesquisa
        //    if (nomegrupo != NomeGrupo)
        //    {
        //        Assert.Fail("Falha no cadastro, grupo  " + NomeGrupo + "   NÃO ENCONTRADO.");
        //    }

        //    //Verifica se o componente switch está ativo

        //    Sw.SwitchAtivo(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div"), "Class",
        //    "thf-switch-container thf-clickable thf-switch-container-off", "O NOVO GRUPO está INATIVO");

        //    Thread.Sleep(3000);
        //}
        #endregion





    }
}
