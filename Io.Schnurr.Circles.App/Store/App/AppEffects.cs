using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<AppState> state;
    private const string persistanceName = "circles-app";

    public AppEffects(ILocalStorageService localStorageService, IState<AppState> state)
    {
        this.localStorageService = localStorageService;
        this.state = state;
    }

    [EffectMethod(typeof(PersistState))]
    public async Task PersistState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, state!.Value);
    }

    [EffectMethod(typeof(InitializeState))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultState());
            dispatcher.Dispatch(new PersistState());
        }
        else
        {
            dispatcher.Dispatch(new SetState(storageState));
        }
    }
}

public record SetState(AppState state);
public record PersistState();
public record InitializeState();