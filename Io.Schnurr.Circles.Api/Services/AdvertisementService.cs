using Io.Schnurr.Circles.Api.TestData;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.Services;

internal static class AdvertisementService
{
    private static readonly IEnumerable<Advertisement> advertisements = TestAdvertisements.GetAdvertisements();

    internal static async Task<IResult> GetAll()
    {
        await SimulateLoading();
        IEnumerable<Advertisement> result = advertisements.Where(a => a.DeletedAt == null);
        return TypedResults.Ok(result);
    }

    internal static async Task<IResult> GetByUser(string userMailAddress)
    {
        await SimulateLoading();
        IEnumerable<Advertisement> result = advertisements.Where(a => a.DeletedAt == null && a.CreatedBy.ToLower() == userMailAddress);
        return TypedResults.Ok(result);
    }

    internal static async Task<IResult> CreateOrUpdate(Advertisement advertisement)
    {
        // TODO: ADD Automatic FluentValidation on this type
        await SimulateLoading();

        if (advertisement == null)
        {
            throw new ArgumentNullException(nameof(advertisement));
        }

        return Results.Ok();

        //TODO: Implement CreateOrUpdate();
        //var advertisementIndex = advertisements.ToList().FindIndex(a => a.Id == advertisement.Id);

        //if (advertisementIndex == -1)
        //{
        //    // Simulate create
        //    advertisement.Id = advertisements.Max(a => a.Id) + 1;
        //    advertisement.CreatedAt = DateTime.UtcNow;
        //    advertisements.ToList().Add(advertisement);
        //    return TypedResults.Created($"/{nameof(advertisement)}/{advertisement.Id}", advertisement);
        //}
        //else
        //{
        //    // Simulate update
        //    advertisements.ElementAt(advertisementIndex).= advertisement;
        //    return Results.NoContent();
        //}
    }

    internal static void MapRoutes(WebApplication app)
    {
        // Using MapGroup to not duplicate "/advertisement/..." in mappings
        var advertisement = app.MapGroup(nameof(Advertisement));
        advertisement.MapGet("/", AdvertisementService.GetAll);
        advertisement.MapGet("/{userMailAddress}", AdvertisementService.GetByUser);
        advertisement.MapPost("/", AdvertisementService.CreateOrUpdate);
    }

    private static async Task SimulateLoading() => await Task.Delay(new Random().Next(500, 2500));
}