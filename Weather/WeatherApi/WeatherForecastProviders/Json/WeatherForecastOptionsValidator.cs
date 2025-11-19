using Microsoft.Extensions.Options;
using WeatherApi.WeatherForecastProviders.Helpers;

namespace WeatherApi.WeatherForecastProviders.Json;

public class WeatherForecastOptionsValidator : IValidateOptions<WeatherForecastOptions>
{
    public ValidateOptionsResult Validate(string? name, WeatherForecastOptions options)
    {
        var duplicateDates = WeatherForecastValidationHelper
            .GetDuplicateDates(options.WeatherForecast)
            .ToArray();

        if (duplicateDates.Length != 0)
        {
            return ValidateOptionsResult.Fail(
                $"Duplicate forecast dates found: " +
                $"{string.Join(", ", duplicateDates.Select(d => d.ToString("yyyy-MM-dd")))}"
            );
        }

        return ValidateOptionsResult.Success;
    }
}