using Blazored.LocalStorage;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Saves the state to localStorage after dispatching an action.
/// To be persisted the state needs to obtain the <see cref="PersistStateAttribute"/> and the action needs to derive from <see cref="PersistAfterDispatchAction{T}"/>.
/// </summary>
public class StatePersistance<T> : Fluxor.Middleware
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
            var persistanceName = PersistStateAttribute.GetPersistanceName<T>();
            await localStorageService.SetItemAsync(persistanceName, persistAction.state);
        }
    }
}