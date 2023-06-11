using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod]
    public static AppState SetAppState(AppState state, SetAppState action) => action.AppState;

    [ReducerMethod(typeof(SetDefaultAppState))]
    public static AppState SetDefaultAppState(AppState state) => new AppState();
}

public class SetDefaultAppState { }