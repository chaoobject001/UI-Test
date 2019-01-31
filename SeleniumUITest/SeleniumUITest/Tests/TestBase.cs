using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUITest.Pages;
using System.Configuration;


namespace SeleniumUITest.Tests
{
    [TestClass]
    public class TestBase
    {

        protected static IWebDriver driver;

        public TestContext TestContext { get; set; }

        private string appURL;

        public HomePage homePage;

        public TestBase() { }

        [TestInitialize]
        public void CreateDriver()
        {
            appURL = ConfigurationManager.AppSettings.Get("BaseURL");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Given user load page URL
            driver.Navigate().GoToUrl(appURL + "/");
            homePage = new HomePage(driver);
        }

        [TestCleanup]
        public void QuitDriver()
        {
            if (driver != null)
                driver.Quit();
        }


        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {
            DisposeDriverService.FinishHim(driver);
        }
    }
}
