using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using WeatherTest.Dto;
using WeatherTest.Pages;
using WeatherTest.Services;

namespace WeatherTest.Tests;

[AllureNUnit]
[TestFixture]
[AllureSuite("Weather Forecast Data Tests")]
public class WeatherForecastDataTests : TestBase
{
    private HttpClient _client;
    private WeatherPage _page;
    private IWeatherForecastSource _source;

    [SetUp]
    public void Init()
    {
        var blazorWeatherBaseAddress = Config["BlazorWeather:BaseAddress"]
                                       ?? throw new InvalidOperationException("BlazorWeather:BaseAddress is null");

        _page = new WeatherPage(Driver, blazorWeatherBaseAddress);

        _client = new HttpClient();
        var weatherApiBaseAddress = Config["WeatherApi:BaseAddress"]
                                    ?? throw new InvalidOperationException("WeatherApi:BaseAddress is null");

        _source = new HttpWeatherForecastSource(_client, weatherApiBaseAddress);
    }

    [Test]
    [AllureTag("UI", "Data")]
    [AllureSubSuite("Table Validation")]
    public async Task WeatherTableMatchesApi()
    {
        AllureApi.Step("Navigate to Weather page", () =>
        {
            _page.Navigate();
        });

        List<WeatherForecastDto> tableData = null!;
        AllureApi.Step("Read data from weather table", () =>
        {
            tableData = _page.GetForecastTable().ToList();
        });

        List<WeatherForecastDto> sourceData = null!;
        await AllureApi.Step("Fetch data from API", async () =>
        {
            sourceData = (await _source.GetForecastAsync()).ToList();
        });

        AllureApi.Step("Compare UI table data and API data", () =>
        {
            Assert.That(tableData, Is.EqualTo(sourceData));
        });
    }

    [TearDown]
    public void Cleanup()
    {
        _client.Dispose();
    }
}