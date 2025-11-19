using WeatherTest.Dto;
using OpenQA.Selenium;

namespace WeatherTest.Pages;

public class WeatherPage
{
    private readonly IWebDriver _driver;
    private readonly string _url;

    public WeatherPage(IWebDriver driver, string baseUrl)
    {
        _driver = driver;
        _url = $"{baseUrl}/weather";
    }

    public void Navigate() => _driver.Navigate().GoToUrl(_url);

    public IEnumerable<WeatherForecastDto> GetForecastTable()
    {
        var rows = _driver.FindElements(By.CssSelector("table tbody tr"));
        foreach (var row in rows)
        {
            var cells = row.FindElements(By.TagName("td"));
            yield return new WeatherForecastDto(
                Date: DateOnly.Parse(cells[0].Text),
                TemperatureC: int.Parse(cells[1].Text),
                Summary: cells[3].Text
            );
        }
    }
}