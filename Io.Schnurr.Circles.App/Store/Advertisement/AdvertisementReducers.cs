using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public static class AdvertisementReducer
{
    [ReducerMethod]
    public static AdvertisementState SetAdvertisements(AdvertisementState state, SetAdvertisementsAction action) => state with { Items = action.Advertisements };

    [ReducerMethod]
    public static AdvertisementState SetAdvertisementStateIsLoading(AdvertisementState state, SetAdvertisementStateIsLoadingAction action) => state with { IsLoading = action.IsLoading };
}

public record SetAdvertisementsAction(IEnumerable<Shared.Models.Advertisement> Advertisements);
public record SetAdvertisementStateIsLoadingAction(bool IsLoading);