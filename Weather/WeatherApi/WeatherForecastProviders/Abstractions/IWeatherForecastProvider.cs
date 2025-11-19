namespace WeatherApi.WeatherForecastProviders.Abstractions;

public interface IWeatherForecastProvider
{
    IReadOnlyList<WeatherForecastDto> GetForecast();
}