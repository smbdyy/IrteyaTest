using Microsoft.Extensions.Options;
using WeatherApi.WeatherForecastProviders.Abstractions;
using WeatherApi.WeatherForecastProviders.Json;

namespace WeatherApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJsonWeatherForecastProvider(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<WeatherForecastOptions>(
            configuration.GetSection(WeatherForecastOptions.SectionName)
        );
        
        services.AddSingleton<IValidateOptions<WeatherForecastOptions>, WeatherForecastOptionsValidator>();

        services.AddScoped<IWeatherForecastProvider, JsonWeatherForecastProvider>();

        return services;
    }
}