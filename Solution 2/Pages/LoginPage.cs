using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Solution_2.Pages;

public class LoginPage
{
    private IWebDriver driver;

    private IWebElement EmailField => driver.FindElement(By.Id("email"));
    private IWebElement ContinueButton => driver.FindElement(By.CssSelector("button.bg-secondary-blue-400"));
    private IWebElement PasswordField => driver.FindElement(By.CssSelector("input[type='password'].border-grey-80.w-full.rounded-md"));
    private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("span.text-secondary-red-400"));

    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public async Task EnterEmail(string email)
    {
        EmailField.Clear();
        EmailField.SendKeys(email);
    }

    public async Task EnterPassword(string password)
    {
        var passwordField = wait.Until(driver => PasswordField);
        passwordField.Clear();

        passwordField.SendKeys(password);
    }

    public async Task ClickContinueButton()
    {
        ContinueButton.Click();
    }

    public string GetErrorMessage()
    {
        return ErrorMessage.Text;
    }
}