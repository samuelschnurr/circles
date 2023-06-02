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
    [ReducerMethod(typeof(ToggleDrawerAction))]
    public static AppState ReduceToggleDrawerAction(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };

    [ReducerMethod(typeof(ToggleDarkModeAction))]
    public static AppState ReduceToggleDarkModeAction(AppState state) => state with { IsDarkMode = !state.IsDarkMode };
}


public class ToggleDrawerAction { }

public class ToggleDarkModeAction { }