using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI._2._Interactions
{
    public class IntMesas : Po_Mesas
    {
        IWebDriver driver;
        WaitElement Wait;
        ValidarMsg Msg;
        Select_Element Select;
        IntCommon intCommon;

        public IntMesas(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
            Msg = new ValidarMsg(driver);
            Select = new Select_Element(driver);
            intCommon = new IntCommon(driver);
        }

        public void BtnAdicionarMesas()
        {
            Wait.LocateElementAndClick(By.XPath(btnAdicionarMesa));

            var titulo = driver.FindElement(By.XPath(TituloModal)).Text;
            Assert.AreEqual("Adicionar nova mesa", titulo);
        }

        public void DadosMesa(string CodMesa, string posicao/*, string Praca*/)
        {
            driver.FindElement(By.XPath(Codmesa)).SendKeys(CodMesa.ToString());
            driver.FindElement(By.XPath(posicoes)).SendKeys(posicao.ToString());
            //Select.ByText(By.ClassName(praca), Praca);

        }
        public void BtnSalvar(string msg)
        {
            driver.FindElement(By.XPath(btnSalvar)).Click();
            Msg.ValidaMsg(msg);
        }

        public void Editar()
        {
            intCommon.MenuEditarList();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(Codmesa)).Clear();
            Thread.Sleep(500);
        }

        public void Excluir(string msg)
        {
            intCommon.MenuExcluirList();
            Thread.Sleep(500);
            intCommon.ConfirmarExc();
            Msg.ValidaMsg(msg);
        }


    }
}
