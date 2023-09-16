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
        return TypedResults.Ok(result);
    }

    internal static async Task<IResult> GetById(int id)
    {
        // Simulate loading
        await Task.Delay(new Random().Next(500, 2500));
        return advertisements.SingleOrDefault(a => a.Id == id && a.DeletedAt == null)
        is Advertisement advertisement
        ? TypedResults.Ok(advertisement)
        : TypedResults.NotFound();
    }

    internal static async Task<IResult> GetByUser()
    {
        // Simulate loading
        await Task.Delay(new Random().Next(500, 2500));
        IEnumerable<Advertisement> result = advertisements.Where(a => a.DeletedAt == null && a.CreatedBy.ToLower() == TestUserContext.MailAddress.ToLower());
        return TypedResults.Ok(result);
    }

    internal static void MapRoutes(WebApplication app)
    {
        // Using MapGroup to not duplicate "/advertisement/..." in mappings
        var advertisement = app.MapGroup(nameof(Advertisement));
        advertisement.MapGet("/", AdvertisementService.GetAll);
        advertisement.MapGet("/{id}", AdvertisementService.GetById);
    }
}