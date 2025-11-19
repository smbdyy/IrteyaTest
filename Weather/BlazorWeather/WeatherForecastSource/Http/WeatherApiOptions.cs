namespace BlazorWeather.WeatherForecastSource.Http;

public class WeatherApiOptions
{
    public const string SectionName = "WeatherApi";
    
    public string BaseAddress { get; set; } = string.Empty;
}