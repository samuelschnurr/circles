using Fluxor;

namespace Io.Schnurr.Circles.App.Store;

[FeatureState]
public record AppState
{
    public bool IsDrawerOpen { get; init; } = true;

    public AppState() { }
}

public static class AppReducer
{
    [ReducerMethod(typeof(ToggleDrawerAction))]
    public static AppState ReduceToggleDrawerAction(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };
}


public class ToggleDrawerAction { }