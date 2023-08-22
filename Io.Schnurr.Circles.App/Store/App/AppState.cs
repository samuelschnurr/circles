using Fluxor;
using Io.Schnurr.Circles.App.Store.Base;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.App;

[FeatureState]
[PersistState("circles-app")]
public record AppState : BaseState
{
    internal bool IsDrawerOpen { get; init; } = true;
    public bool IsDarkMode { get; init; } = false;

    public AppState() { }
}