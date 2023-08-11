using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    // Better would be to create separate reducers or effects for each action
    // This would improve state tracing in DevTools, clean accessing of state transformation methods instead of access in components and more
    // But for simplification reasons in this prototype I use a single SetState reducer
    [ReducerMethod]
    public static AppState SetState(AppState state, SetStateAction action) => action.State;
}

public record SetStateAction(AppState State) : PersistAfterDispatchAction<AppState>(State);