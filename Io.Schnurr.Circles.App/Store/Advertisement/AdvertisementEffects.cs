using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public class AdvertisementEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly AdvertisementService advertisementService;
    private readonly IState<AdvertisementState> advertisementState;

    public AdvertisementEffects(ILocalStorageService localStorageService, AdvertisementService advertisementService, IState<AdvertisementState> advertisementState)
    {
        this.localStorageService = localStorageService;
        this.advertisementService = advertisementService;
        this.advertisementState = advertisementState;
    }

    [EffectMethod(typeof(PersistStateAction<AdvertisementState>))]
    public async Task PersistState()
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<AdvertisementState>();
        await localStorageService.SetItemAsync(persistanceName, advertisementState.Value);
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