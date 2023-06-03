using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

[FeatureState]
public record AppState
{
    public bool IsDrawerOpen { get; init; } = true;
    public bool IsDarkMode { get; init; } = false;

    public AppState() { }
}