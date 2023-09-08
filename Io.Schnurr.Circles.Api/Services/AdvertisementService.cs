﻿using Io.Schnurr.Circles.Api.TestData;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.Services;

internal static class AdvertisementService
{
    private static readonly IEnumerable<Advertisement> advertisements = TestAdvertisements.GetAdvertisements();

    internal static IResult GetAll()
    {
        IEnumerable<Advertisement> result = advertisements.Where(o => o.DeletedAt == null);
        return TypedResults.Ok(result);
    }

    internal static IResult GetById(int id)
    {
        return advertisements.SingleOrDefault(o => o.Id == id && o.DeletedAt == null)
        is Advertisement advertisement
        ? TypedResults.Ok(advertisement)
        : TypedResults.NotFound();
    }

    internal static void MapRoutes(WebApplication app)
    {
        // Using MapGroup to not duplicate "/advertisement/..." in mappings
        var advertisement = app.MapGroup(nameof(Advertisement));
        advertisement.MapGet("/", AdvertisementService.GetAll);
        advertisement.MapGet("/{id}", AdvertisementService.GetById);
    }
}