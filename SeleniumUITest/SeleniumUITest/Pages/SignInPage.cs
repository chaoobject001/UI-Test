using OpenQA.Selenium;

namespace SeleniumUITest.Pages
{
    public class SignInPage
    {
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LoginBtn => driver.FindElement(By.ClassName("login"));
        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        public IWebElement SubmitLoginBtn => driver.FindElement(By.Id("SubmitLogin"));

        public MyAccountPage SignIn(string email, string password) {
            LoginBtn.Click();
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            SubmitLoginBtn.Click();
            return new MyAccountPage(driver);
        }

        public MyAccountPage SignInFromCart(string email, string password) {
            LoginBtn.Click();
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            SubmitLoginBtn.Click();
            
            return new MyAccountPage(driver);
        }
    }
}
