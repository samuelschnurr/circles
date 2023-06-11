using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod]
    public static AppState SetState(AppState state, SetState action) => action.state;

    [ReducerMethod(typeof(SetDefaultState))]
    public static AppState SetDefaultState(AppState state) => new AppState();
}

public class SetDefaultState { }