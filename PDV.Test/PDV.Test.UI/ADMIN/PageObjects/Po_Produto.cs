using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PDV.Test.UI._1._CommonMethods;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;
using System.Windows;


namespace PDV.Test.UI.ADMIN.PageObjects
{
    public class Po_Produto
    {
        public string btnAdicionarProduto = "//div/div[1]/div/thf-button/button";
        public string nomeproduto = "thf-input";
        public string codinterno = "//div/div[2]/div/div[1]/thf-input[2]/thf-field-container/div/div[2]/input";
        public string grupo = "//div/div[1]/thf-multiselect/thf-field-container/div/div[2]/input";
        public string unimedida = "//div/div[1]/thf-select/thf-field-container/div/select";
        public string PrUnitario = "//thf-decimal/thf-field-container/div/div[2]/input";
        public string grupoproduto = "//div/thf-multiselect-search/div/input";
        public string Clickgrupoproduto = "//div/thf-multiselect-dropdown/div/ul/thf-multiselect-item/li/a";
        public string modificadores = "//div[2]/div/thf-multiselect/thf-field-container/div/thf-multiselect-dropdown/div/thf-multiselect-search/div/input";
        public string cliquemodificadores = "//div[2]/div/thf-multiselect/thf-field-container/div/div[2]/div[1]/span";
        public string cliquemodifdetalhes = "//div[2]/div/thf-multiselect/thf-field-container/div/thf-multiselect-dropdown/div/ul/thf-multiselect-item/li/a/label";
        public string cliquefiscais = "//div[4]/ni-collapsible-widget/div/div[2]/div/div/thf-select/thf-field-container/div/div[2]/div/div/span";
        public string salvar = "//div[6]/thf-button[2]/button/span";
        public string msg = "/html/body/thf-toaster/div";
        public string trespontos = "//div/div/div/div/div/table/tbody/tr/td[7]/span";
        public string editar = "//div/div/div/div/div/thf-popup/div/div[2]";


    }
}
