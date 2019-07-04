using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI.POS.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void BtnAdicionarGrupo ()
        {
            Wait.LocateElementAndClick(By.XPath("//div/div[1]/div/thf-button/button"));
        }

        public void CadastrarNovoGrupo(string NomeGrupo, int GrupoFixo)
        {
            Wait.LocateElement(By.XPath("//thf-modal/div/div/div/div/div/div[1]/div")); //Titulo Modal 

            var nomegrupo = driver.FindElement(By.XPath("//thf-input/thf-field-container/div/div[2]/input"));
            nomegrupo.SendKeys(NomeGrupo);
            Thread.Sleep(1000);

            
            SelectElement grupofixo = new SelectElement(driver.FindElement(By.XPath("//thf-select/thf-field-container/div/select")));                       
            grupofixo.SelectByValue(GrupoFixo.ToString());

        }

        public void IconeGrupo()
        {
            driver.FindElement(By.XPath("//pos-item-card[1]/div/div/div/img")).Click(); // ìcone Bebida
        }






    }
}
