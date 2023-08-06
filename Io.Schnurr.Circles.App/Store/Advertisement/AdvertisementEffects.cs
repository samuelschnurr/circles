using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public class AdvertisementEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-advertisement";

    public AdvertisementEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod]
    public async Task UpdateState(UpdateStateAction action, IDispatcher dispatcher)
    {
        var newState = action!.state;
        dispatcher.Dispatch(new SetStateAction(newState));
        await localStorageService.SetItemAsync(persistanceName, newState);
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AdvertisementState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new UpdateStateAction(new AdvertisementState()));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

public record UpdateStateAction(AdvertisementState state);
public record InitializeStateAction();