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
    class AllMicePage : Page
    {
        private const string PAGE_URL = "https://www.razer.com/shop/mice/gaming-mice";
        const string allMicePrefix = @"//*[@class='cx-product-container']//app-razer-product-grid-item";

        [FindsBy(How = How.XPath, Using = allMicePrefix)]
        private IList<IWebElement> allMice;

        private IWebElement firstAvailableMouseToCart;

        public AllMicePage(IWebDriver driver) : base(driver)
        {

        }

        public AddedProductPage AddFirstAvailableMouseToCart()
        {
            foreach (IWebElement mouse in allMice)
            {
                IWebElement targetMouse = FindElementByClassName(mouse, "add-to-cart-btn");
                if (targetMouse != null && targetMouse.Text.ToUpper().Contains("ADD TO CART"))
                {
                    return new AddedProductPage(driver, targetMouse);
                }
            }
            return null;

        }

        public string NameFirstAvailableMouseToCart()
        {
            foreach (IWebElement mouse in allMice)
            {

                IWebElement targetMouse = FindElementByClassName(mouse, "add-to-cart-btn");
                if (targetMouse != null && targetMouse.Text.ToUpper().Contains("ADD TO CART"))
                {
                    firstAvailableMouseToCart = mouse;
                    string nameMouse = firstAvailableMouseToCart.FindElement(By.ClassName("product-item-title")).Text;
                    return nameMouse;
                }

            }
            return null;

        }

        public IWebElement FindElementByClassName(IWebElement webElement, string searchAttribute)
        {
            try
            {
                IWebElement requiredElement = webElement.FindElement(By.ClassName(searchAttribute));
                return requiredElement;
            }
            catch
            {
                return null;
            }
        }

        protected override Page openPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            WaitAnswerFromPage();
            WaitLoadedPage();
            PageFactory.InitElements(driver, page: this);
            return this;
        }
        public AllMicePage OpenCurrentPage()
        {
            return (AllMicePage)openPage();
        }
    }
}
