using Io.Schnurr.Circles.Shared;

namespace Io.Schnurr.Circles.Api.Services;

internal static class WeatherForecastService
{
    #region MockDB

    private static readonly string[] summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    private static readonly IEnumerable<WeatherForecast> weatherForecasts = Enumerable.Range(1, 5).Select(index =>
              new WeatherForecast()
              {
                  Id = index,
                  Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                  TemperatureC = Random.Shared.Next(-20, 55),
                  Summary = summaries[Random.Shared.Next(summaries.Length)]
              });


    #endregion

    internal static IResult GetAll()
    {
        return TypedResults.Ok(weatherForecasts.ToList());
    }

    internal static IResult GetById(int id)
    {
        return weatherForecasts.SingleOrDefault(w => w.Id == id)
            is WeatherForecast forecast
            ? TypedResults.Ok(forecast)
            : TypedResults.NotFound();
    }
}