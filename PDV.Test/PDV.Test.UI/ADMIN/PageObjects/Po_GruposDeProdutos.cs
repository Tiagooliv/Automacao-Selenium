using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class IntGruposDeProdutos
    {
        public string btnAdicionarGrupo = "thf-button-sm";
        public string TituloModal = "thf-modal-title";
        public string nomeGrupo = "//div[2]//div[1]/div[1]/thf-input/thf-field-container/div/div[2]/input";
        public string grupoFixo = "thf-select";
        public string IconeSobremesa = "//ni-item-card[3]/div/div/div/img";
        public string btnSalvar = "//div[3]/thf-button[2]/button";
        public string Msg = "/html/body/thf-toaster/div/div";
                                             
    }
}
