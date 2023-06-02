using Fluxor;

namespace Io.Schnurr.Circles.App.Store;

[FeatureState]
public class AppState
{
    public bool IsDrawerOpen { get; } = true;

    public AppState()
    {

    }

    public AppState(bool isDrawerOpen)
    {
        IsDrawerOpen = isDrawerOpen;
    }
}

public static class AppReducer
{
    [ReducerMethod(typeof(ToggleDrawerAction))]
    public static AppState ReduceToggleDrawerAction(AppState state) => new AppState(!state.IsDrawerOpen);
}


public class ToggleDrawerAction { }