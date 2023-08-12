using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public static class AdvertisementReducer
{
    [ReducerMethod]
    public static AdvertisementState SetAdvertisements(AdvertisementState state, SetAdvertisementsAction action) => state with { Items = action.Advertisements };

    [ReducerMethod(typeof(SetDefaultStateAction))]
    public static AdvertisementState SetDefaultState(AdvertisementState state) => new();

    [ReducerMethod]
    public static AdvertisementState SetStateFromLocalStorage(AdvertisementState state, SetStateFromLocalStorageAction action) => action.State;
}

[PersistAfterDispatch]
public record SetAdvertisementsAction(IEnumerable<Shared.Models.Advertisement> Advertisements);

[PersistAfterDispatch]
public record SetDefaultStateAction();

public record SetStateFromLocalStorageAction(AdvertisementState State);