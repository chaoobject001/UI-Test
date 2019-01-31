using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITest.Pages
{
    public class PaymentPage
    {
        private IWebDriver driver;
        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string totalPayment => driver.FindElement(By.Id("total_price")).Text;

        public IWebElement BankWireOption => driver.FindElement(By.ClassName("bankwire"));
        public IWebElement ConfirmOrderOption => driver.FindElement(By.XPath("//*[@id='cart_navigation']/*[@type='submit']"));
        public string OrderCompleteMSG => driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong")).Text;

        public PaymentPage SelectBankWireOption() {
            BankWireOption.Click();
            return this;
        }

        public PaymentPage ConfirmOrder() {
            ConfirmOrderOption.Click();
            return this;
        }



    }
}
