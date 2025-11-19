using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WeatherTest.Tests;

public abstract class TestBase
{
    protected IWebDriver Driver;
    protected IConfiguration Config;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    [SetUp]
    public void SetupDriver()
    {
        var chromeOptions = new ChromeOptions();
        if (Config.GetValue<bool>("WebDriver:Headless"))
            chromeOptions.AddArgument("--headless");

        Driver = new ChromeDriver(chromeOptions);
    }

    [TearDown]
    public void TearDownDriver()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}