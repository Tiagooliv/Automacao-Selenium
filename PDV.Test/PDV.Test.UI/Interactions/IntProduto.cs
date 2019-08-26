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
            var txtProduto = driver.FindElement(By.ClassName(nomeproduto));
            txtProduto.SendKeys(NomeProduto);

            var txtcodinterno = driver.FindElement(By.XPath(codinterno));
            txtcodinterno.SendKeys(CodInterno);
            txtcodinterno.SendKeys(Keys.Tab);

            var txtgrupo = driver.FindElement(By.XPath(grupo));
            txtgrupo.Click();
            txtgrupo.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);

            var txtgrupoproduto = driver.FindElement(By.XPath(grupoproduto));
            txtgrupoproduto.SendKeys(GrupoProduto);
            var cliquegrupo = driver.FindElement(By.XPath(Clickgrupoproduto));
            cliquegrupo.Click();
            txtgrupoproduto.SendKeys(Keys.Tab);

            //Select.ByText(By.ClassName("thf-select"),UnidMedida);
            var txtunimedida = driver.FindElement(By.XPath(unimedida));
            txtunimedida.SendKeys(Keys.ArrowDown);
            txtunimedida.SendKeys(Keys.ArrowDown);
            txtunimedida.SendKeys(UnidMedida);
            txtunimedida.SendKeys(Keys.Enter);

            var txtprUnitario = driver.FindElement(By.XPath(PrUnitario));
            txtprUnitario.SendKeys(PrUnitario);
        }

        public void Detalhes(string Modificadores)
        {
            var CliqueModificadores = driver.FindElement(By.XPath(cliquemodificadores));

            CliqueModificadores.Click();

            var txtmodificadores = driver.FindElement(By.XPath(modificadores));

            txtmodificadores.SendKeys(Modificadores);

            var CliqueModifiDetalhes = driver.FindElement(By.XPath(cliquemodifdetalhes));

            CliqueModifiDetalhes.Click();

            txtmodificadores.SendKeys(Keys.Tab);
        }

        public void Fiscais()
        {
            var CliqueFiscais = driver.FindElement(By.XPath(cliquefiscais));

            CliqueFiscais.Click();

            CliqueFiscais.Click();
        }

        public void BtnSalvar()
        {
            driver.FindElement(By.XPath(salvar)).Click();//Salvar
            Wait.LocateElement(By.XPath(msg)); //Aguarda mensagem na tela

            // Valida a mensagem  
            var Msg = driver.FindElement(By.XPath(msg)).Text;
            Assert.AreEqual("Produto cadastrado com sucesso.", Msg);
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
            var txtnomeproduto = driver.FindElement(By.XPath(nomeproduto));
            txtnomeproduto.Clear();
            txtnomeproduto.SendKeys(NomeProduto);

            var txtcodinterno = driver.FindElement(By.XPath(codinterno));
            txtcodinterno.Clear();
            txtcodinterno.SendKeys(CodInterno);
            txtcodinterno.SendKeys(Keys.Tab);

            var txtgrupo = driver.FindElement(By.XPath(grupo));
            txtgrupo.Clear();
            txtgrupo.Click();
            txtgrupo.SendKeys(Keys.ArrowDown);
            Thread.Sleep(500);

            var txtgrupoproduto = driver.FindElement(By.XPath(grupoproduto));
            txtgrupoproduto.Clear();
            txtgrupoproduto.SendKeys(GrupoProduto);
            var cliquegrupo = driver.FindElement(By.XPath(Clickgrupoproduto));
            cliquegrupo.Click();
            txtgrupoproduto.SendKeys(Keys.Tab);

            //Select.ByText(By.ClassName("thf-select"),UnidMedida);
            var txtunimedida = driver.FindElement(By.XPath(unimedida));
            txtunimedida.Clear();
            txtunimedida.SendKeys(Keys.ArrowDown);
            txtunimedida.SendKeys(Keys.ArrowDown);
            txtunimedida.SendKeys(UnidMedida);
            txtunimedida.SendKeys(Keys.Enter);

            var txtprUnitario = driver.FindElement(By.XPath(PrUnitario));
            txtprUnitario.Clear();
            txtprUnitario.SendKeys(PrUnitario);
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
