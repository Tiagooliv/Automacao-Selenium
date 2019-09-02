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
            Wait.LocateElementAndClick(By.XPath(TresPontosList));
        }

        public void MenuEditarList()
        {
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


    }
}
