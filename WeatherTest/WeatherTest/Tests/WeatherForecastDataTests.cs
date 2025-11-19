using WeatherTest.Pages;
using WeatherTest.Services;

namespace WeatherTest.Tests;

[TestFixture]
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
        
        _page = new WeatherPage(Driver,  blazorWeatherBaseAddress);

        _client = new HttpClient();
        var weatherApiBaseAddress = Config["WeatherApi:BaseAddress"]
            ?? throw new InvalidOperationException("WeatherApi:BaseAddress is null");
        
        _source = new HttpWeatherForecastSource(_client, weatherApiBaseAddress);
    }

    [Test]
    public async Task WeatherTableMatchesApi()
    {
        _page.Navigate();
        var tableData = _page.GetForecastTable().ToList();
        var apiData = (await _source.GetForecastAsync()).ToList();

        Assert.That(tableData, Is.EqualTo(apiData));
    }

    [TearDown]
    public void Cleanup()
    {
        _client.Dispose();
    }
}