using Blazored.LocalStorage;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Saves the state to localStorage after dispatching an action, if the state is tagged with <see cref="PersistStateAttribute"/>.
/// </summary>
public class StatePersistance : Fluxor.Middleware
{
    private readonly ILocalStorageService localStorageService;

    public StatePersistance(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override async void AfterDispatch(object action)
    {
        //PersistAfterDispatchAction<T>? persistAction = action as PersistAfterDispatchAction<T>;

        //if (persistAction != null)
        //{
        //    await localStorageService.SetItemAsync(persistAction.state.PersistanceName, persistAction.state);
        //}
    }
}