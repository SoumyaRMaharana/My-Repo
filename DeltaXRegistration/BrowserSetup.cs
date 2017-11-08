using DeltaXRegistration.Page_Object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaXRegistration
{

    [SetUpFixture]
    public class BrowserSetup
    {
        public IWebDriver WebDriver { get; private set; }

        [OneTimeSetUp]
        public void BeforeTest()
        {
            this.WebDriver = new ChromeDriver();
            this.WebDriver.Manage().Window.Maximize();
            this.WebDriver.Navigate().GoToUrl("http://adjiva.com/qa-test/");
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            this.WebDriver.Quit();
        }

        static void Main(string[] args)
        {

        }     
    }
}
