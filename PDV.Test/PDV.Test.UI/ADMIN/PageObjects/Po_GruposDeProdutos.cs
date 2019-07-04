using OpenQA.Selenium;
using PDV.Test.UI.POS.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public void BtnAdicionarGrupo ()
        {

        }


    }
}
