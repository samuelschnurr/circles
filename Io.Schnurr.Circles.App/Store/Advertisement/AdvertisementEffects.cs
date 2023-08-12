using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public class AdvertisementEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly AdvertisementService advertisementService;

    public AdvertisementEffects(ILocalStorageService localStorageService, AdvertisementService advertisementService)
    {
        this.localStorageService = localStorageService;
        this.advertisementService = advertisementService;
    }

    [EffectMethod(typeof(LoadAdvertisementsAction))]
    public async Task LoadAdvertisements(IDispatcher dispatcher)
    {
        var data = await advertisementService.GetAll();
        dispatcher.Dispatch(new SetAdvertisementsAction(data));
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<AdvertisementState>();
        var storageState = await localStorageService.GetItemAsync<AdvertisementState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultStateAction());
        }
        else
        {
            dispatcher.Dispatch(new SetStateFromLocalStorageAction(storageState));
        }
    }
}

public record LoadAdvertisementsAction();

[InitializeOnStartup]
public record InitializeStateAction();