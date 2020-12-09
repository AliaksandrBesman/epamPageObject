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

namespace WebDriverLab.pageobject_model
{
    class CustomConditions
    {
        public static Func<IWebDriver, object> JQueryAJAXsCompleted(IWebDriver driver)
        {
            Func<IWebDriver, object> fa = o => ((bool)((IJavaScriptExecutor)
            driver).ExecuteScript("return (window.jQuery != null) && (jQuery.active == 0);"));
            return fa;
        }
    }
}
