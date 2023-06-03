using Fluxor;

namespace Io.Schnurr.Circles.App.Store;

[FeatureState]
public record AppState
{
    public bool IsDrawerOpen { get; init; } = true;
    public bool IsDarkMode { get; init; } = false;

    public AppState() { }
}

public static class AppReducer
{
    [ReducerMethod(typeof(OnIsDrawerOpenChangedAction))]
    public static AppState ReduceOnIsDrawerOpenChangedAction(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };

    [ReducerMethod(typeof(OnIsDarkModeChangedAction))]
    public static AppState ReduceOnIsDarkModeChangedAction(AppState state) => state with { IsDarkMode = !state.IsDarkMode };
}


public class OnIsDrawerOpenChangedAction { }

public class OnIsDarkModeChangedAction { }