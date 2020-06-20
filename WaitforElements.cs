using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickTest
{
    public class WaitforElements
    {
        public void wait4elementbyCss(IWebDriver driver, string css)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(30);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Until(x => x.FindElement(By.CssSelector(css)));

        }

        public void wait4elementbyID(IWebDriver driver, string id)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(30);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Until(x => x.FindElement(By.CssSelector(id)));
        }

    }
}
