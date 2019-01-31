using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITest.Pages
{
    public class AddressPage
    {
        private IWebDriver driver;

        public AddressPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Name => driver.FindElement(By.XPath("//*[@id='address_delivery']/*[@class='address_firstname address_lastname']")).Text;
        public string StreetAddress => driver.FindElement(By.XPath("//*[@id='address_delivery']/*[@class='address_address1 address_address2']")).Text;
        public string CityStateZipcode => driver.FindElement(By.XPath("//*[@id='address_delivery']/*[@class='address_city address_state_name address_postcode']")).Text;
        public string Country => driver.FindElement(By.XPath("//*[@id='address_delivery']/*[@class='address_country_name']")).Text;
        public IWebElement ProcessAddress => driver.FindElement(By.Name("processAddress"));

        public ShippingPage ProceedToShipping() {
            ProcessAddress.Click();
            return new ShippingPage(driver);
        }
        
    }
}
