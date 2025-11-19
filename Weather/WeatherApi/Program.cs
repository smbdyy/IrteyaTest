using WeatherApi;
using WeatherApi.WeatherForecastProviders.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Configuration.AddJsonFile("Resources/forecast.json", optional: false, reloadOnChange: true);
builder.Services.AddJsonWeatherForecastProvider(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/weather", (IWeatherForecastProvider provider) => provider.GetForecast());

app.Run();
