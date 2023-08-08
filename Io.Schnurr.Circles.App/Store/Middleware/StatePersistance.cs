using Blazored.LocalStorage;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Saves the state to local storage after dispatching.
/// </summary>
public class StatePersistance<T> : Fluxor.Middleware where T : PersistableState
{
    private readonly ILocalStorageService localStorageService;

    public StatePersistance(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override async void AfterDispatch(object action)
    {
        PersistAfterDispatchAction<T>? persistAction = action as PersistAfterDispatchAction<T>;

        if (persistAction != null)
        {
            await localStorageService.SetItemAsync(persistAction.state.PersistanceName, persistAction.state);
        }
    }
}
