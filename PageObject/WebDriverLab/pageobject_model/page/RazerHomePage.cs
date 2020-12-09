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

namespace WebDriverLab.pageobject_model.page
{
    class RazerHomePage : Page
    {


        public RazerHomePage(IWebDriver driver) : base(driver)
        {

        }

        public AllMicePage OpenAllMicePage()
        {
            return new AllMicePage(driver);
        }

        protected override Page openPage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);

            return this;
        }
        public RazerHomePage OpenCurrentPage()
        {
            return (RazerHomePage)openPage();
        }
    }
}
