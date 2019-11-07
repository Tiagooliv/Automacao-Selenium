using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;


namespace PDV.Test.UI._1._CommonMethods
{
    public class ValidarSwitch
    {
        IWebDriver driver;

        public ValidarSwitch(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SwitchAtivo(By locator, string NomeAtributo, string ValorAtributo, string Msg)
        {
            var Switch = driver.FindElement(locator).GetAttribute(NomeAtributo);

            if (Switch.Equals(ValorAtributo))
            {
                Assert.Fail(Msg);
            }

            // By locator    = identificação do componente (xpath, name, id...)
            // Nometributo   = nome do atributo que deseja pegar o valor
            // ValorAtributo = Valor do atributo escolhido
            // MSg           = Mensagem de retorno ao falhar o teste

        }
    }
}
