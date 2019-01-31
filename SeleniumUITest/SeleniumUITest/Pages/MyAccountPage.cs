using OpenQA.Selenium;

namespace SeleniumUITest.Pages
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title() {
            return driver.Title;
        }

        public IWebElement ErrorMSG => driver.FindElement(By.XPath("//*[@class='alert alert-danger']/ol/li"));
        public IWebElement ShoppingCartIcon => driver.FindElement(By.XPath("//*[@class='shopping_cart']/a"));
        public IWebElement ProceedToCheckout => driver.FindElement(By.XPath("//*[@class='cart_navigation clearfix']/a[@title='Proceed to checkout']"));

        public AddressPage ReturnToCart() {
            ShoppingCartIcon.Click();
            ProceedToCheckout.Click();
            return new AddressPage(driver);
        }
    }
}

