using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.App;

[FeatureState]
public record AppState : PersistableState
{
    internal override string PersistanceName => "circles-app";
    internal bool IsDrawerOpen { get; init; } = true;
    public bool IsDarkMode { get; init; } = false;

    public AppState() { }
}