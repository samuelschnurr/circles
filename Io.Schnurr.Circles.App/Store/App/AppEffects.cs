using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-app";

    public AppEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetStateAction(new AppState()));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

public record InitializeStateAction();