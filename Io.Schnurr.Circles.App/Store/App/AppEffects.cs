using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class BoardEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-app";

    public BoardEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod]
    public async Task PersistState(OnPersistAppStateAction action, IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, action.AppState);
    }

    [EffectMethod(typeof(OnLoadAppStateAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        var appState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (appState == null)
        {
            dispatcher.Dispatch(new OnInitializeAppStateAction());
            // TODO: dispatcher.Dispatch(new OnPersistAppStateAction());
        }
        else
        {
            dispatcher.Dispatch(new OnSetAppStateAction(appState));
        }
    }
}

public record OnSetAppStateAction(AppState AppState);
public record OnPersistAppStateAction(AppState AppState);
public record OnLoadAppStateAction();