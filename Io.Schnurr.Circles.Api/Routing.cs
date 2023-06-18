using Io.Schnurr.Circles.Api.Services;

namespace Io.Schnurr.Circles.Api
{
    internal static class Routing
    {
        internal static void MapRoutes(this WebApplication app)
        {
            OfferService.MapRoutes(app);
        }
    }
}
