using Io.Schnurr.Circles.Api.TestData;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.Services;

internal static class AdvertisementService
{
    private static readonly IEnumerable<Advertisement> advertisements = TestAdvertisements.GetAdvertisements();

    internal static async Task<IResult> GetAll()
    {
        // Simulate loading
        await Task.Delay(new Random().Next(500, 2500));
        IEnumerable<Advertisement> result = advertisements.Where(a => a.DeletedAt == null);
        return result.Any() ? TypedResults.Ok(result) : TypedResults.NoContent();
    }

    internal static async Task<IResult> GetByUser(string userMailAddress)
    {
        // Simulate loading
        await Task.Delay(new Random().Next(500, 2500));
        IEnumerable<Advertisement> result = advertisements.Where(a => a.DeletedAt == null && a.CreatedBy.ToLower() == userMailAddress);
        return result.Any() ? TypedResults.Ok(result) : TypedResults.NoContent();
    }

    internal static void MapRoutes(WebApplication app)
    {
        // Using MapGroup to not duplicate "/advertisement/..." in mappings
        var advertisement = app.MapGroup(nameof(Advertisement));
        advertisement.MapGet("/", AdvertisementService.GetAll);
        advertisement.MapGet("/{userMailAddress}", AdvertisementService.GetByUser);
    }
}