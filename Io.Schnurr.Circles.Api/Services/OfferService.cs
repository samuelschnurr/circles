using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Api.Services;

internal static class OfferService
{
    #region MockDB

    private static readonly IEnumerable<Offer> offers = Enumerable.Range(1, 50).Select(index =>
              new Offer()
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
        return TypedResults.Ok(offers.ToList());
    }

    internal static IResult GetById(int id)
    {
        return offers.SingleOrDefault(w => w.Id == id)
            is Offer offer
            ? TypedResults.Ok(offer)
            : TypedResults.NotFound();
    }

    internal static void MapRoutes(WebApplication app)
    {
        // Using MapGroup to not duplicate "/offer/..." in mappings
        var offer = app.MapGroup(nameof(Offer));
        offer.MapGet("/", OfferService.GetAll);
        offer.MapGet("/{id}", OfferService.GetById);
    }
}