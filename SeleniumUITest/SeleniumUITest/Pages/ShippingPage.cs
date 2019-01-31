using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUITest.Pages
{
    public class ShippingPage
    {
        private IWebDriver driver;

        public ShippingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyCarrierRadioBTN => driver.FindElement(By.Id("delivery_option_129888_0"));
        public IWebElement AgreeToTermsAndServicesCheckBox => driver.FindElement(By.Id("cgv"));
        public IWebElement ProceedToPaymentBtn => driver.FindElement(By.Name("processCarrier"));

        public ShippingPage SelectMyCarrier() {
            MyCarrierRadioBTN.Click();
            return this;
        }

        public ShippingPage AgreeToTermsAndServices() {
            AgreeToTermsAndServicesCheckBox.Click();
            return this;
        }

        public PaymentPage ProceedToPayment() {
            ProceedToPaymentBtn.Click();
            return new PaymentPage(driver);
        }


    }
}
