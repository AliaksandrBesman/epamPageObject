using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverLab.pageobject_model.page;

namespace WebDriverLab
{
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void BrowserSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.razer.com/");
        }


        [Test]
        public void GetItemAddedToCartAndCompareWithSelectedOne()
        {
            RazerHomePage page = new RazerHomePage(driver);
            AllMicePage allMicePage =
                page.OpenCurrentPage()
                .OpenAllMicePage();
            string nameFirstAvaliableMouseToCart = allMicePage.OpenCurrentPage().NameFirstAvailableMouseToCart();
            CartPage cartPage =
            allMicePage
                .AddFirstAvailableMouseToCart()
                .OpenCurrentPage()
                .GoToCart()
                .OpenCurrentPage()
                ;
            string nameAddedItem = cartPage.NameTargetItem();
            int numberItemInCart = cartPage.NumberItemInCart();
            Assert.IsTrue(nameAddedItem == nameFirstAvaliableMouseToCart && numberItemInCart == 1);

        }

        [Test]
        public void GetNumberIdenticalAddedProduct()
        {

            AllMicePage allMicePage = new AllMicePage(driver);

            string nameFirstAvaliableMouseToCart = allMicePage.OpenCurrentPage().NameFirstAvailableMouseToCart();
            AddedProductPage addedProductPage =
            allMicePage
                .AddFirstAvailableMouseToCart()
                .OpenCurrentPage();
            CartPage cartPage =
            allMicePage.OpenCurrentPage()
                .AddFirstAvailableMouseToCart()
                .OpenCurrentPage()
                .GoToCart()
                .OpenCurrentPage()
                ;
            string nameAddedItem = cartPage.NameTargetItem();
            int numberTargetItem = cartPage.NumberTargetItem();
            int numberItemInCart = cartPage.NumberItemInCart();
            Assert.IsTrue(nameAddedItem == nameFirstAvaliableMouseToCart && numberItemInCart == 1 && numberTargetItem == 2);

        }

        [TearDown]
        public void BrowserTearDown()
        {
            if (driver != null)
                driver.Quit();
        }

    }
}
