using WeatherApi.WeatherForecastProviders.Abstractions;

namespace WeatherApi.WeatherForecastProviders.Helpers;

public static class WeatherForecastValidationHelper
{
    public static IEnumerable<DateOnly> GetDuplicateDates(IEnumerable<WeatherForecastDto> forecast)
        => forecast
            .GroupBy(f => f.Date)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);
}