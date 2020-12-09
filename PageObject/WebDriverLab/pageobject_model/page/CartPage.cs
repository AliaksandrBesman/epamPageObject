using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLab.pageobject_model.page
{
    class CartPage : Page
    {
        private const string PAGE_URL = "https://www.razer.com/cart";

        const string allAddedItemPrefix = @"//*[contains(@class,'cx-item-list-row')]";
        private IWebElement moveToThisPageButton;
        [FindsBy(How = How.XPath, Using = allAddedItemPrefix)]
        private IList<IWebElement> allAddedItem;
        [FindsBy(How = How.XPath, Using = allAddedItemPrefix)]
        private IWebElement targetItem;
        private int indexTargetItem = 1;

        public CartPage(IWebDriver driver, IWebElement targetButton) : base(driver)
        {
            this.moveToThisPageButton = targetButton;
        }
        public CartPage(IWebDriver driver) : base(driver)
        {

        }

        public string NameTargetItem()
        {
            return targetItem.FindElement(By.XPath("//*[contains(@class,'cx-name')]")).Text;
        }

        public int NumberTargetItem()
        {
            return int.Parse(targetItem.FindElement(By.XPath("//*[contains(@class,'mat-select-value')]")).Text);
        }
        public int NumberItemInCart()
        {
            return allAddedItem.Count;
        }
        public void NextItem()
        {
            if (indexTargetItem + 1 > allAddedItem.Count)
                indexTargetItem = 1;
            else
                indexTargetItem++;

            targetItem = allAddedItem[indexTargetItem];
        }

        protected override Page openPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", moveToThisPageButton);
            WaitAnswerFromPage();
            WaitLoadedPage();
            PageFactory.InitElements(this.driver, page: this);
            return this;
        }

        public CartPage OpenCurrentPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            WaitAnswerFromPage();
            WaitLoadedPage();
            driver.Navigate().Refresh();
            WaitAnswerFromPage();
            WaitLoadedPage();
            PageFactory.InitElements(this.driver, page: this);
            return this;
        }
    }
}
