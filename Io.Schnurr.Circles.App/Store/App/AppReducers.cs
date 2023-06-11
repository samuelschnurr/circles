using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod]
    public static AppState SetState(AppState state, SetStateAction action) => action.state;
}

public record SetStateAction(AppState state) { }