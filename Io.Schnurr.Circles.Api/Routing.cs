using Io.Schnurr.Circles.Api.Services;
using Io.Schnurr.Circles.Shared;

namespace Io.Schnurr.Circles.Api
{
    internal static class Routing
    {
        internal static void MapRoutes(this WebApplication app)
        {
            app.MapRoutes<WeatherForecast>();
        }

        internal static void MapRoutes<WeatherForecast>(this WebApplication app)
        {
            // Using MapGroup to not duplicate "/weatherforecast/..." in mappings
            var weatherforecast = app.MapGroup(nameof(WeatherForecast));
            weatherforecast.MapGet("/", WeatherForecastService.GetAll);
            weatherforecast.MapGet("/{id}", WeatherForecastService.GetById);
        }
    }
}
