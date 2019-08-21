using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace PDV.Test.UI._1._CommonMethods
{
    public class ValidarCadastro
    {
        IWebDriver driver;
        ValidarSwitch Sw;

        public ValidarCadastro(IWebDriver driver)
        {
            this.driver = driver;
            Sw = new ValidarSwitch(driver);
        }

        public void ValidaCadastro(string Text)
        {
            driver.FindElement(By.ClassName("thf-input-icon-left")).SendKeys(Text);  //Pesquisa o novo cadastro            
            var Textresult = driver.FindElement(By.XPath("//table/tbody[1]/tr/td[2]/div/span")).Text;  //Guarda o primeiro resultado da lista

            if (Textresult != Text)
            {
                Assert.Fail("Falha no cadastro, " + Text + "   NÃO ENCONTRADO.");
            }

            Sw.SwitchAtivo(By.XPath("//td[1]/div/span/thf-switch/thf-field-container/div/div[2]/div"), "Class",
            "thf-switch-container thf-clickable thf-switch-container-off", "O NOVO CADASTRO está INATIVO");
            Thread.Sleep(3000);
        }

    }
}
