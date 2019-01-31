using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumUITest.Pages;
using System.Configuration;

namespace SeleniumUITest.Tests
{
    [TestClass]
    public class PurchaseFlowTest : TestBase
    {
        private SummaryPage summaryPage;
        private SignInPage signInPage;
        private MyAccountPage myAccountPage;
        private AddressPage addressPage;
        private ShippingPage shippingPage;
        private PaymentPage paymentPage;

        [TestMethod]
        public void PurchaseOneItem()
        {
            // Given user adds one item to cart
            summaryPage = homePage.SelectFirstItem();

            // And user sees correct total price
            string totalPrice = summaryPage.TotalPrice.Text;
            string expectedTotalPrice = ConfigurationManager.AppSettings.Get("TotalPrice");
            Assert.IsTrue(totalPrice.Equals(expectedTotalPrice), "Verify total price");
            signInPage = summaryPage.ProceedToCheckout();

            // And users sign in with valid credential
            myAccountPage = signInPage
                .SignInFromCart(ConfigurationManager.AppSettings.Get("Email")
                    , ConfigurationManager.AppSettings.Get("Password"));
            addressPage = myAccountPage.ReturnToCart();

            // And user sees address information 
            string name = ConfigurationManager.AppSettings.Get("AddressInfo_Name");
            string street = ConfigurationManager.AppSettings.Get("AddressInfo_Street");
            string cityStateZipcode = ConfigurationManager.AppSettings.Get("AddressInfo_CityStateZipcode");
            string country = ConfigurationManager.AppSettings.Get("AddressInfo_Country");
            Assert.IsTrue(addressPage.Name.Equals(name), "Verify name on address page");
            Assert.IsTrue(addressPage.StreetAddress.Equals(street), "Verify street address on address page");
            Assert.IsTrue(addressPage.CityStateZipcode.Equals(cityStateZipcode), "Verify City, State and Zipcode on address page");
            Assert.IsTrue(addressPage.Country.Equals(country), "Verify country on address page");

            shippingPage = addressPage.ProceedToShipping();

            // And user select shipping method 
            // And user agree to terms and condition
            paymentPage = shippingPage
                .SelectMyCarrier()
                .AgreeToTermsAndServices()
                .ProceedToPayment();

            // And user sees payment information
            Assert.IsTrue(paymentPage.totalPayment.Equals(expectedTotalPrice), "Verify total payment on address page");

            // And user selects payment method "Pay by bank wire"
            paymentPage
                .SelectBankWireOption()
                .ConfirmOrder(); // When user confirms order

            // Then user sees message "Your order on My Store is complete."
            Assert.IsTrue(paymentPage.OrderCompleteMSG.Equals("Your order on My Store is complete."), "Verify order complete message");
        }
    }
}
