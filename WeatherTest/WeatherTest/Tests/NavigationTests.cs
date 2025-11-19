using WeatherTest.Pages;

namespace WeatherTest.Tests;

[TestFixture]
public class NavigationTests : TestBase
{
    private NavMenuPage _nav;

    [SetUp]
    public void Init()
    {
        var blazorWeatherBaseAddress = Config["BlazorWeather:BaseAddress"]
            ?? throw new InvalidOperationException("BlazorWeather:BaseAddress is null");
        
        Driver.Navigate().GoToUrl(blazorWeatherBaseAddress);
        _nav = new NavMenuPage(Driver);
    }

    [Test]
    public void CanNavigateToHome()
    {
        _nav.NavigateToHome();
        Assert.That(Driver.Url, Does.EndWith("/")); // проверка на Index
    }

    [Test]
    public void CanNavigateToWeather()
    {
        _nav.NavigateToWeather();
        Assert.That(Driver.Url, Does.EndWith("/weather"));
    }

    [Test]
    public void CanNavigateToCounter()
    {
        _nav.NavigateToCounter();
        Assert.That(Driver.Url, Does.EndWith("/counter"));
    }
}