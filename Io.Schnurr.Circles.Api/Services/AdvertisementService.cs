using FluentValidation;
using Io.Schnurr.Circles.Api.TestData;
using Io.Schnurr.Circles.Shared.Models;
using Io.Schnurr.Circles.Shared.TestData;

namespace Io.Schnurr.Circles.Api.Services;

internal static class AdvertisementService
{
    internal static async Task<IResult> GetAll()
    {
        await SimulateLoading();
        IEnumerable<Advertisement> result = TestAdvertisements.advertisements.Where(a => a.DeletedAt == null);
        return TypedResults.Ok(result);
    }

    internal static async Task<IResult> GetByUser(string userMailAddress)
    {
        await SimulateLoading();
        IEnumerable<Advertisement> result = TestAdvertisements.advertisements.Where(a => a.DeletedAt == null && a.CreatedBy.ToLower() == userMailAddress);
        return TypedResults.Ok(result);
    }

    internal static async Task<IResult> CreateOrUpdate(IValidator<Advertisement> validator, Advertisement advertisement)
    {
        await SimulateLoading();
        var validationResult = await validator.ValidateAsync(advertisement);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        if (!SimulateAuthorization(advertisement.CreatedBy))
        {
            return TypedResults.Unauthorized();
        }

        var dbAdvertisements = TestAdvertisements.advertisements;
        var advertisementIndex = dbAdvertisements.FindIndex(a => a.Id == advertisement.Id);

        if (advertisementIndex == -1)
        {
            // Simulate create
            advertisement.Id = dbAdvertisements.Max(a => a.Id) + 1;
            advertisement.CreatedAt = DateTime.UtcNow;
            dbAdvertisements.Add(advertisement);
            return TypedResults.Created($"/{nameof(advertisement)}/{advertisement.Id}", advertisement);
        }
        else
        {
            // Simulate update
            dbAdvertisements[advertisementIndex] = advertisement;
            return Results.NoContent();
        }
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

    private static bool SimulateAuthorization(string userMail) => string.Equals(userMail.ToLower(), TestUserContext.MailAddress.ToLower());
}