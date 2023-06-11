using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<AppState> appState;
    private const string persistanceName = "circles-app";

    public AppEffects(ILocalStorageService localStorageService, IState<AppState> appState)
    {
        this.localStorageService = localStorageService;
        this.appState = appState;
    }

    [EffectMethod(typeof(PersistAppState))]
    public async Task PersistAppState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, appState!.Value);
    }

    [EffectMethod(typeof(InitializeAppState))]
    public async Task InitializeAppState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultAppState());
            dispatcher.Dispatch(new PersistAppState());
        }
        else
        {
            dispatcher.Dispatch(new SetAppState(storageState));
        }
    }
}

public record SetAppState(AppState AppState);
public record PersistAppState();
public record InitializeAppState();