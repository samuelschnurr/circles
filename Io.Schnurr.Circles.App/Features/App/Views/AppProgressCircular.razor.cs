using Fluxor;
using Io.Schnurr.Circles.App.Features.App.Store;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Features.App.Views;

public partial class AppProgressCircular
{
    [Inject]
    private IState<AppState> AppState { get; set; }

    public bool IsDrawerOpen => AppState.Value.IsDrawerOpen;
}
