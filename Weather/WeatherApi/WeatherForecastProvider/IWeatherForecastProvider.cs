namespace WeatherApi.WeatherForecastProvider;

public interface IWeatherForecastProvider
{
    IReadOnlyList<WeatherForecastDto> GetForecast();
}