using OpenQA.Selenium;

namespace Solution_2.Pages;

public class HomePage
{
    private IWebDriver driver;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public bool IsUserLoggedIn()
    {
        return driver.Url.Contains("client/web");
    }

    public bool IsNoteDisplayed(string noteTitle)
    {
        return driver.PageSource.Contains(noteTitle);
    }

}
