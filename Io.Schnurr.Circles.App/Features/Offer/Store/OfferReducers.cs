using Fluxor;
using Io.Schnurr.Circles.Shared.Models;
using static Io.Schnurr.Circles.App.Features.Offer.Store.OfferActions;

namespace Io.Schnurr.Circles.App.Features.Offer.Store;

public static class OfferReducer
{
    [ReducerMethod]
    public static OfferState SetAdvertisements(OfferState state, SetAdvertisementsAction action) => state with { Items = action.Advertisements ?? new List<Advertisement>() };

    [ReducerMethod]
    public static OfferState SetOfferStateIsLoading(OfferState state, SetOfferStateIsLoadingAction action) => state with { IsLoading = action.IsLoading };
}