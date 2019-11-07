using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Test.UI.ADMIN.PageObjects
{
   public class Po_Mesas
    {
        public string btnAdicionarMesa = "//div[1]/div/thf-button/button/span";
        public string TituloModal = "//thf-modal/div/div/div/div/div/div[1]/div";
        public string Codmesa = "//thf-decimal/thf-field-container/div/div[2]/input";
        public string btnGerarNum = "//div/div/form/div/div[1]/div/thf-button/button/span";
        public string posicoes = "//thf-number/thf-field-container/div/div[2]/input";
        public string praca = "thf-select"; /*"//thf-select/thf-field-container/div/div[2]/div";*/
        public string btnSalvar = "//thf-button[2]/button/span";

    }
}
