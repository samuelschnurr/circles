using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.Services;

internal static class AdvertisementService
{
    #region MockDB

    private static readonly IEnumerable<Advertisement> advertisements = Enumerable.Range(1, 50).Select(index =>
              new Advertisement()
              {

                  Id = index,
                  Title = "Title" + index,
                  Image = new(),
                  CreatedAt = DateTime.Now.AddDays(-index),
                  DeletedAt = index % 4 == 0 ? DateTime.Now.AddMinutes(-index) : null,
                  Description = "Description Description" + index,
                  Price = 1.3M * index,
              });


    #endregion

    internal static IResult GetAll()
    {
        return TypedResults.Ok(advertisements.Where(o => o.DeletedAt == null));
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