using OpenQA.Selenium;

namespace WeatherTest.Pages;

public class NavMenuPage
{
    private readonly IWebDriver _driver;

    public NavMenuPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void NavigateToHome() => NavigateTo("");
    public void NavigateToWeather() => NavigateTo("weather");
    public void NavigateToCounter() => NavigateTo("counter");
    
    private void NavigateTo(string href)
        => _driver.FindElement(By.CssSelector($"a[href='{href}']")).Click();
}