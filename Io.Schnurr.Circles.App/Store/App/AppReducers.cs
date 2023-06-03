using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod(typeof(OnIsDrawerOpenChangedAction))]
    public static AppState HandleIsDrawerOpenChangedAction(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };

    [ReducerMethod(typeof(OnIsDarkModeChangedAction))]
    public static AppState HandleIsDarkModeChangedAction(AppState state) => state with { IsDarkMode = !state.IsDarkMode };
}


public class OnIsDrawerOpenChangedAction { }

public class OnIsDarkModeChangedAction { }