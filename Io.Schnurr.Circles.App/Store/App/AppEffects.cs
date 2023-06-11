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

    [EffectMethod(typeof(OnPersistAppStateAction))]
    public async Task PersistState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, appState!.Value);
    }

    [EffectMethod(typeof(OnInitializeAppStateAction))]
    public async Task InitializeAppState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new OnSetDefaultAppStateAction());
            dispatcher.Dispatch(new OnPersistAppStateAction());
        }
        else
        {
            dispatcher.Dispatch(new OnSetAppStateAction(storageState));
        }
    }
}

public record OnSetAppStateAction(AppState AppState);
public record OnPersistAppStateAction();
public record OnInitializeAppStateAction();