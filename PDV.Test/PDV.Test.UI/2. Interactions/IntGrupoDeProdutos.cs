using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class IntGrupoDeProdutos : IntGruposDeProdutos
    {
        public IWebDriver driver;
        WaitElement Wait;
        ValidarSwitch Sw;
        ValidarCadastro Vc;
        Select_Element Select;

        public IntGrupoDeProdutos(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Sw = new ValidarSwitch(driver);
            Vc = new ValidarCadastro(driver);
            Select = new Select_Element(driver);
        }

        public void BtnAdicionarGrupo()
        {
            Wait.LocateElementAndClick(By.ClassName(btnAdicionarGrupo));
        }

        public void DadosdoGrupo(string NomeGrupo, string GrupoFixo)
        {            
            Wait.LocateElement(By.ClassName(TituloModal));//Titulo Modal
            driver.FindElement(By.XPath(nomeGrupo)).SendKeys(NomeGrupo);
            Select.ByText(By.ClassName(grupoFixo), GrupoFixo);
        }

        public void IconeGrupo()
        {        
            driver.FindElement(By.XPath(IconeSobremesa)).Click();
        }

        public void BtnSalvar()
        {
            //Salvar
            driver.FindElement(By.XPath(btnSalvar)).Click();

            //Aguarda mensagem na tela "Cadastro com sucesso"
            Wait.LocateElement(By.XPath(Msg));

            //Guarda mensagem
            var msg = driver.FindElement(By.XPath(Msg)).Text;

            // Valida a mensagem 
            Assert.AreEqual("Grupo criado com sucesso", msg);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(Msg)).Click();
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

        public void Editar()
        {
            driver.FindElement(By.XPath(nomeGrupo)).Clear();            
        }





    }
}
