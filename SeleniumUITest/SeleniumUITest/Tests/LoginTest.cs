using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumUITest.Pages;
using System.Configuration;

namespace SeleniumUITest.Tests
{
    [TestClass]
    public class LoginTest : TestBase
    {
        private SignInPage signInPage;
        private MyAccountPage myAccountPage;

        public LoginTest() { }

        [TestMethod]
        public void SignInWithValidCredential()
        {
            //When users sign in with valid credential
            signInPage = new SignInPage(driver);
            string email = ConfigurationManager.AppSettings.Get("Email");
            string password = ConfigurationManager.AppSettings.Get("Password");
            myAccountPage = signInPage.SignIn(email, password);
            //Then user is navigate to page titled "My account - My Store" PageTitle
            Assert.IsTrue(myAccountPage.Title()
                .Equals(ConfigurationManager.AppSettings.Get("PageTitle")), "Verified title of the page");
        }

        [TestMethod]
        public void SignInWithInvalidCredential()
        {
            //When users sign in with Invalid credential
            signInPage = new SignInPage(driver);
            string invalidEmail = ConfigurationManager.AppSettings.Get("InvalidEmail");
            string invalidPassword = ConfigurationManager.AppSettings.Get("InvalidPassword");
            myAccountPage = signInPage.SignIn(invalidEmail, invalidPassword);
            //Then user is prompted with error message "Invalid password." "
            Assert.IsTrue(myAccountPage.ErrorMSG.Text
                .Equals(ConfigurationManager.AppSettings.Get("WrongPasswordMSG")), "Verify error message for invalid password");
        }
    }
}
