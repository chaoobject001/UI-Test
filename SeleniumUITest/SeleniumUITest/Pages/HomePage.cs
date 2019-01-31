using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITest.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstItem => driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div/div/a"));
        public IWebElement AddToCartBTN => driver.FindElement(By.Id("add_to_cart"));
        public IWebElement CheckoutBTN => driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));

        public SummaryPage SelectFirstItem()
        {
            FirstItem.Click(); // select first item
            AddToCartBTN.Click();
            CheckoutBTN.Click(); // enter Summary stage of Cart
            return new SummaryPage(driver);
        }
    }
}
