using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Solution_2;

public static class SeleniumHelper
{
    public static IWebDriver InitializeDriver()
    {
        var options = new ChromeOptions();
        options.AddArguments("--start-maximized");
        return new ChromeDriver(options);
    }
}
