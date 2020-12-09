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
    abstract class Page
    {
        protected IWebDriver driver;
        protected abstract Page openPage();
        protected const int WAIT_TIMEOUT_SECONDS = 10;
        protected const string HOMEPAGE_URL = @"https://www.razer.com/";

        protected Page(IWebDriver driver)
        {
            this.driver = driver;
        }
        protected void WaitAnswerFromPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
          .Until(CustomConditions.JQueryAJAXsCompleted(driver));

        }
        protected void WaitLoadedPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
    }
}
