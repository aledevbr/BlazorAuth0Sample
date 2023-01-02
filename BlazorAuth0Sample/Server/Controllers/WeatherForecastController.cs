using BlazorAuth0Sample.Shared;

using Microsoft.AspNetCore.Mvc;

namespace BlazorAuth0Sample.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly List<WeatherForecast> forecasts = new();

    static WeatherForecastController()
    {
        forecasts.AddRange(Enumerable.Range(1,5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }));
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get() 
        => forecasts;

    [HttpPost]
    public WeatherForecast CreateForecast(WeatherForecast forecast)
    {
        forecasts.Add(forecast);
        return forecast;
    }

}
