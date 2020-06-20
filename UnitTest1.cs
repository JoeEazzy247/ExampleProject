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
    public class UnitTest1
    {
        public IWebDriver driver;
        WebDriverWait wait;
        DefaultWait<IWebDriver> fluentwait;
        [Test]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Url = "http://www.ankpro.com/";
            driver.Url = "http://uitestpractice.com/students/Select";

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));//Webdriver wait syntax
         
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));//webdriver ignore syntax

            fluentwait = new DefaultWait<IWebDriver>(driver);//Fluent wait syntax
            fluentwait.Timeout = TimeSpan.FromSeconds(5);//Fluent wait timeout
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);//fluent wait pollingInterval
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found";



            //var login = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText
            //("Log in")));
            //login.Click();//Using webdriver wait to click login by linktext


            //var login = fluentwait.Until(z=> z.FindElement(By.LinkText
            //("Log in")));
            //login.Click();//Using webdriver wait to click login by linktext

            //var checkbox = fluentwait.Until(m => m.FindElement(By.XPath
            //(".//*[starts-with(@id,'Rem')]")));
            //checkbox.Click();

            //bool selected = driver.FindElement(By.XPath(".//*[starts-with(@id,'Rem')]")).Selected;
            //bool selected = driver.FindElement(By.CssSelector("input[type=checkbox]:checked")).Selected;
            //Console.WriteLine(selected);

            //Console.WriteLine(selected);
            /*if (selected==true)
            {

                Console.WriteLine("Checkbox is selected");
                
            }
            else if (selected==false)
            {
                Console.WriteLine("Checkbox is not selected");
                var checkbox = fluentwait.Until(x => x.FindElement(By.XPath
                                        (".//*[starts-with(@id,'Rem')]")));
                checkbox.Click();
                Console.WriteLine("Checkbox is now selected");  

            }

            bool submitbtn = driver.FindElement(By.CssSelector("input[type=submit]")).Displayed;
            if (submitbtn == true)
            {
                Console.WriteLine("Btn is displayed");
            }
            else
            {
                Console.WriteLine("Btn not displayed");
            }*/

            try
            {
                string choice = "China";
                var element = fluentwait.Until(x => x.FindElement(By.Id("countriesSingle")))
                                                         .FindElements(By.TagName("option"));


                for (var i = 0; i < element.Count; i++)
                {
                    element[i].Click();
                    Console.WriteLine(element[i].Text);
                 
                    if (element[i].Text == choice)
                    {
                      
                        break;
                    }
                   
                }

                SelectElement Multiple = new SelectElement(driver.FindElement(By.Id("countriesMultiple")));
                foreach (var option in Multiple.Options)
                {
                
                    option.Click();
                    Console.WriteLine(option.Text);
                    Thread.Sleep(1000);
                    if (option.Text=="England")
                    {
                        break;
                    }
                }
                      
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (driver!=null)
                {
                    driver.Quit();
                }
            }

            Thread.Sleep(3000);
            driver.Quit();

        }

    }
}
