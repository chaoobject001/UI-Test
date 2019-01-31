using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITest.Pages
{
    public class SummaryPage
    {
        private IWebDriver driver;

        public SummaryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TotalPrice => driver.FindElement(By.Id("total_price"));
        public IWebElement ProceedToCheckoutBTN => driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']/*[@title='Proceed to checkout']"));

        public SignInPage ProceedToCheckout() {
            ProceedToCheckoutBTN.Click();
            return new SignInPage(driver);
        }
    }
}
