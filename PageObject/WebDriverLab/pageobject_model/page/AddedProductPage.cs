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
using System.Threading;
using System.Threading.Tasks;

namespace WebDriverLab.pageobject_model.page
{
    class AddedProductPage : Page
    {
        IWebElement targetProduct;
        const string viewCartButtonPrefix = @"//app-razer-main-sku//button[@class='button-primary']";
        [FindsBy(How = How.XPath, Using = viewCartButtonPrefix)]
        private IWebElement viewCartButton;

        public AddedProductPage(IWebDriver driver, IWebElement targetProduct) : base(driver)
        {
            this.targetProduct = targetProduct;
        }

        public CartPage ViewCart()
        {
            return new CartPage(driver, viewCartButton);
        }

        protected override Page openPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", targetProduct);
            WaitAnswerFromPage();
            WaitLoadedCurrentPage();
            PageFactory.InitElements(driver, this);
            return this;
        }
        public AddedProductPage OpenCurrentPage()
        {
            return (AddedProductPage)openPage();
        }

        public CartPage GoToCart()
        {
            WaitAnswerFromPage();
            WaitLoadedPage();
            return new CartPage(driver);
        }

        private void WaitLoadedCurrentPage()
        {
            while(true)
            {
                try
                {
                    IWebElement viewCartButton = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(viewCartButtonPrefix)));
                    if (viewCartButton != null)
                        return;
                }
                catch
                {

                }
            }
           
        }
    }
}
