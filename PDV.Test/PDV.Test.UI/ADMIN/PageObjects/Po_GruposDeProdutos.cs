using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_GruposDeProdutos
    {
        public IWebDriver driver;
        public WaitElement Wait;

        public Po_GruposDeProdutos(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void BtnAdicionarGrupo()
        {
             Wait.LocateElementAndClick(By.ClassName("thf-button-sm"));
        }

        public void DadosdoGrupo(string NomeGrupo, string GrupoFixo)
        {
            Wait.LocateElement(By.ClassName("thf-modal-title")); //Titulo Modal 

            var nomegrupo = driver.FindElement(By.XPath("//div[2]//div[1]/div[1]/thf-input/thf-field-container/div/div[2]/input"));
            nomegrupo.SendKeys(NomeGrupo);

            SelectElement grupofixo = new SelectElement(driver.FindElement(By.ClassName("thf-select")));
            grupofixo.SelectByText(GrupoFixo);
        }

        public void IconeGrupo()
        {
            driver.FindElement(By.XPath("//pos-item-card[1]/div/div/div/img")).Click(); // ìcone Bebida
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath("//div[3]/thf-button[2]/button")).Click();//Salvar
            Wait.LocateElement(By.XPath("/html/body/thf-toaster/div/div")); //Aguarda mensagem na tela

            var Msg = driver.FindElement(By.XPath("/html/body/thf-toaster/div/div")).Text;
            Assert.AreEqual("Grupo criado com sucesso", Msg); // Valida a mensagem                         

        }

        public void ValidarCadastro(string NomeGrupo)
        {
            var Pesquisagrupo = driver.FindElement(By.ClassName("thf-input-icon-left"));                   
            Pesquisagrupo.SendKeys(NomeGrupo);

            var nomegrupo = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;

            if (nomegrupo != NomeGrupo)
            {
                Assert.Fail("Falha no cadastro grupo  " + NomeGrupo + "   não encontrado.");
            }

            Thread.Sleep(3000);
            
        }





    }
}
