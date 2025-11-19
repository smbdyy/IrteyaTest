using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using WeatherTest.Pages;

namespace WeatherTest.Tests;

[AllureNUnit]
[TestFixture]
[AllureSuite("Navigation Tests")]
public class NavigationTests : TestBase
{
    private NavMenuPage _nav;

    [SetUp]
    public void Init()
    {
        var blazorWeatherBaseAddress = Config["BlazorWeather:BaseAddress"]
            ?? throw new InvalidOperationException("BlazorWeather:BaseAddress is null");

        AllureApi.Step("Navigate to base URL", () =>
        {
            Driver.Navigate().GoToUrl(blazorWeatherBaseAddress);
        });

        _nav = new NavMenuPage(Driver);
    }

    [Test]
    [AllureTag("UI", "Navigation")]
    [AllureSubSuite("Home Page Navigation")]
    public void CanNavigateToHome()
    {
        AllureApi.Step("Click Home link", () =>
        {
            _nav.NavigateToHome();
        });
        Assert.That(Driver.Url, Does.EndWith("/"));
    }

    [Test]
    [AllureTag("UI", "Navigation")]
    [AllureSubSuite("Weather Page Navigation")]
    public void CanNavigateToWeather()
    {
        AllureApi.Step("Click Weather link", () =>
        {
            _nav.NavigateToWeather();
        });
        Assert.That(Driver.Url, Does.EndWith("/weather"));
    }

    [Test]
    [AllureTag("UI", "Navigation")]
    [AllureSubSuite("Counter Page Navigation")]
    public void CanNavigateToCounter()
    {
        AllureApi.Step("Click Counter link", () =>
        {
            _nav.NavigateToCounter();
        });
        Assert.That(Driver.Url, Does.EndWith("/counter"));
    }
}