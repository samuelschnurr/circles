using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod]
    public static AppState HandleSetAppState(AppState state, OnSetAppStateAction action) => action.AppState;

    [ReducerMethod(typeof(OnSetDefaultAppStateAction))]
    public static AppState HandleSetDefaultAppStateAction(AppState state) => new AppState();
}

public class OnSetDefaultAppStateAction { }