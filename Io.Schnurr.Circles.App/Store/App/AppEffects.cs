using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<AppState> appState;

    public AppEffects(ILocalStorageService localStorageService, IState<AppState> appState)
    {
        this.localStorageService = localStorageService;
        this.appState = appState;
    }

    [EffectMethod(typeof(PersistStateAction<AppState>))]
    public async Task PersistState(IDispatcher dispatcher)
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<AppState>();
        await localStorageService.SetItemAsync(persistanceName, appState.Value);
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<AppState>();
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

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

[InitializeOnStartup]
public record InitializeStateAction();