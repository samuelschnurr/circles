using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-app-settings";

    public AppEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod]
    public async Task PersistState(AppStatePersistAction action)
    {
        await localStorageService.SetItemAsync(persistanceName, action.AppState);
    }

    [EffectMethod(typeof(AppStateLoadAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        var counterState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (counterState != null)
        {
            dispatcher.Dispatch(new AppStateSetAction(counterState));
        }
    }
}

public record AppStateSetAction(AppState AppState);
public record AppStatePersistAction(AppState AppState);
public record AppStateLoadAction();