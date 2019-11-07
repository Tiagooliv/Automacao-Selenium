using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using POS.PageObjects;
using System.Threading;
using System.Threading.Tasks;

namespace POS.Interactions
{
    public class IntTelaDeLancamentos : Po_TelaDeLancamentos
    {
        IWebDriver driver;
        WaitElement Wait;
        
        public IntTelaDeLancamentos(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void PesquisarProd(string DescProd, string PrecoProd)
        {
            var prod = driver.FindElement(By.ClassName(pesqProd));
            prod.SendKeys(DescProd);
            Thread.Sleep(500);
            prod.SendKeys(Keys.Enter);

            var precoprod = driver.FindElement(By.XPath(precoProd)).Text;
            Assert.AreEqual(PrecoProd, precoprod);
        }

        public void LimparPesquisa()
        {
            Wait.LocateElementAndClick(By.XPath(limpaBusca));
            Thread.Sleep(500);
        }

        public void LancarProd_1UN()
        {
            Thread.Sleep(1000);
            Wait.LocateElementAndClick(By.XPath(cliqueItem));
            LimparPesquisa();
        }

        public void LancarProd_2UN()
        {
            Thread.Sleep(1000);
            Wait.LocateElementAndClick_x2(By.XPath(cliqueItem));
        }

        public void ValidarTotalProd(string ValorTotalProd)
        {
            var valortotprod = driver.FindElement(By.XPath(precoTotalProd)).Text;
            if (valortotprod != ValorTotalProd)
            {
                Assert.Fail(" VALOR TOTAL ESPERADO DO PROD. :" + ValorTotalProd + " \n TOTAL CALCULADO:" + valortotprod);
            }
        }

        public void ValidarSubtotal(string Subtotal)
        {
            var sub = driver.FindElement(By.XPath(subtotal)).Text;
            if (sub != Subtotal)
            {
                Assert.Fail(" SUBTOTAL ESPERADO: " + Subtotal + " \n SUBTOTAL CALCULADO: " + sub);
            }            
        }

        public void ValidarTxServico(string TxServico)
        {
            var tx = driver.FindElement(By.XPath(txservico)).Text;
            if (tx != TxServico)
            {
                Assert.Fail(" TAXA DE SERV. ESPERADA: " + TxServico + " \n TAXA CALCULADA: " + tx);
            }

        }

        public void ValidarDesconto(string TotDesconto)
        {
            var desc = driver.FindElement(By.XPath(descontos)).Text;
            if (desc != TotDesconto)
            {
                Assert.Fail(" DESCONTO ESPERADO: " + TotDesconto + " \n DESCONTO CALCULADO: " + desc);
            }

        }

        public void EnviarPedido()
        {
            Wait.LocateElementAndClick(By.XPath(btnEnviarPed));
            Thread.Sleep(2000);
        }

        public void BtnPagamento()
        {
            Wait.LocateElementAndClick(By.XPath(btnPagamento));
        }        




    }
}
