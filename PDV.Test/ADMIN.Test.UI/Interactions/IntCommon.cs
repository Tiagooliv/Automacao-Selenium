using OpenQA.Selenium;
using PDV.Test.UI.ADMIN.PageObjects;
using PDV.Test.UI.POS.CommonMethods;
using System.Threading;

namespace PDV.Test.UI._2._Interactions
{
    public class IntCommon : Po_Common
    {
        IWebDriver driver;
        WaitElement Wait;
        public IntCommon(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WaitElement(driver);
        }

        public void MenuTresPontosList()
        {
            Thread.Sleep(500);
            Wait.LocateElementAndClick(By.ClassName(TresPontosList));

        }


        public void MenuEditarList()
        {
            //Thread.Sleep(1000);
            MenuTresPontosList();
            Wait.LocateElementAndClick(By.XPath(EditarList));
        }

        public void MenuDuplicarList()
        {
            MenuTresPontosList();
            Wait.LocateElementAndClick(By.XPath(DuplicarList));
        }

        public void MenuExcluirList()
        {
            MenuTresPontosList();
            Wait.LocateElementAndClick(By.XPath(ExcluirList));
        }

        public void ConfirmarExc()
        {
            Wait.LocateElementAndClick(By.XPath(BtnConfirmarExc));
        }

        public void PesqEmpPDV(string Text)
        {
           
            driver.FindElement(By.XPath(PesqPDvEstab)).SendKeys(Text);
            Thread.Sleep(500);
            Wait.LocateElementAndClick(By.ClassName(CliqPDvEstab));
            Thread.Sleep(1000);
        }


    }
}
