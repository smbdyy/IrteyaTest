using Microsoft.Extensions.Options;
using WeatherApi.WeatherForecastProviders.Helpers;

namespace WeatherApi.WeatherForecastProviders.Json;

public class WeatherForecastConfigValidator : IValidateOptions<WeatherForecastConfig>
{
    public ValidateOptionsResult Validate(string? name, WeatherForecastConfig config)
    {
        var duplicateDates = WeatherForecastValidationHelper
            .GetDuplicateDates(config.WeatherForecast)
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