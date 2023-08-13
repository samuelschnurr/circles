using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public static class AdvertisementReducer
{
    [ReducerMethod]
    public static AdvertisementState SetAdvertisements(AdvertisementState state, SetAdvertisementsAction action) => state with { Items = action.Advertisements };
}

public record SetAdvertisementsAction(IEnumerable<Shared.Models.Advertisement> Advertisements);