using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace QuickTest
{
    [TestFixture]
    public class Windowshandlertest
    {
        public IWebDriver driver;
        WebDriverWait wait;
        DefaultWait<IWebDriver> fluentwait;
        [Test]
        public void TestMethod2()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.online.citibank.co.in/";
            

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));//Webdriver wait syntax
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));//webdriver ignore syntax

            fluentwait = new DefaultWait<IWebDriver>(driver);//Fluent wait syntax
            fluentwait.Timeout = TimeSpan.FromSeconds(20);//Fluent wait timeout
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);//fluent wait pollingInterval
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found";


            
                string choice = "#loginId>img";
                var element = fluentwait.Until(x => x.FindElement(By.CssSelector(choice)));
                element.Click();

                var parentwindow = driver.CurrentWindowHandle;
                foreach (var subwindows in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(subwindows);                   
                }

                string expectedmsg = "Enter your User ID using standard keyboard";
                var msg = fluentwait.Until(x => x.FindElement(By.CssSelector(
                                                  "div[class='bold']"))).Text;
                Console.WriteLine(msg);
                var userid = fluentwait.Until(z => z.FindElement(By.CssSelector(
                                                        "input[id='User_Id']")));
                userid.SendKeys("Joseph");

                Assert.IsTrue(msg.Equals(expectedmsg), "Does not match"); //Assert message
                driver.Close(); //Close tab
                driver.SwitchTo().Window(parentwindow);//Switch back to parent window

                
                Thread.Sleep(3000);
                driver.Quit();

        }
        [Test]
        public void TestMethod3()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.online.citibank.co.in/";

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//Webdriver wait syntax
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));//webdriver ignore syntax


            Console.WriteLine(driver.WindowHandles.Count);
            if (driver.WindowHandles.Count == 1)

                Console.WriteLine("True");//Yes if one window is opened
            else
                Console.WriteLine("False");//No if there is more than one window opened

            string loginnew = "#loginId>img";
            var element = wait.Until(x => x.FindElement(By.CssSelector(loginnew)));
            element.Click();

            var parentwindow = driver.WindowHandles[0];//Get currentwindow value 
            
            
            

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string expectedmsg = "Enter your User ID using standard keyboard";
            var msg = wait.Until(x => x.FindElement(By.CssSelector(
                                              "div[class='bold']"))).Text;
            Console.WriteLine(msg);
            var userid = wait.Until(z => z.FindElement(By.CssSelector(
                                                    "input[id='User_Id']")));
            userid.SendKeys("Another one");
            if (driver.WindowHandles.Count == 2)

                Console.WriteLine("True" +" "+ driver.WindowHandles.Count);
            else
                Console.WriteLine("False");

            Assert.IsTrue(msg.Equals(expectedmsg), "Does not match"); //Assert message
            driver.Close(); //Close tab
            driver.SwitchTo().Window(parentwindow);//Switch back to parent window


            Thread.Sleep(3000);
            driver.Quit();
        }

    }
}
