using OpenQA.Selenium;

namespace WeatherTest.Pages;

public class NavMenuPage
{
    private readonly IWebDriver _driver;
    private readonly string _baseUrl;

    public NavMenuPage(IWebDriver driver, string baseUrl)
    {
        _driver = driver;
        _baseUrl = baseUrl;
    }

    public void NavigateToHome() => _driver.FindElement(By.CssSelector("a[href='/']")).Click();
    public void NavigateToWeather() => _driver.FindElement(By.CssSelector("a[href='/weather']")).Click();
}