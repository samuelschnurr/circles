using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public class AdvertisementEffects
{
    private readonly ILocalStorageService localStorageService;

    public AdvertisementEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var persistanceName = PersistableState.GetPersistanceName<AdvertisementState>();
        var storageState = await localStorageService.GetItemAsync<AdvertisementState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetStateAction(new AdvertisementState()));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

[InitializeOnStartup]
public record InitializeStateAction();