using System.Reflection;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Saves the state to localStorage after dispatching an action.
/// To be persisted the state needs to obtain the <see cref="PersistStateAttribute"/> and the action the <see cref="PersistAfterDispatchAttribute"/>.
/// </summary>
public class StatePersistance<T> : Fluxor.Middleware
{
    private readonly IDispatcher dispatcher;

    public StatePersistance(IDispatcher dispatcher)
    {
        this.dispatcher = dispatcher;
    }

    public override void AfterDispatch(object action)
    {
        var actionType = action.GetType();
        var persistAttribute = actionType.GetCustomAttribute<PersistAfterDispatchAttribute>();

        if (persistAttribute != null)
        {
            dispatcher.Dispatch(new PersistStateAction<T>());
        }
    }
}