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

    [EffectMethod]
    public async Task UpdateState(UpdateStateAction action, IDispatcher dispatcher)
    {
        var newState = action!.state;
        dispatcher.Dispatch(new SetStateAction(newState));
        await localStorageService.SetItemAsync(persistanceName, newState);
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new UpdateStateAction(new AppState()));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

public record UpdateStateAction(AppState state);
public record InitializeStateAction();