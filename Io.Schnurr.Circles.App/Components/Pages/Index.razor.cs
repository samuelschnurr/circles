using Fluxor;
using Io.Schnurr.Circles.App.Store.Advertisement;
using Io.Schnurr.Circles.App.Store.App;
using Io.Schnurr.Circles.App.Store.Board;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Pages;

public partial class Index
{
    [Inject]
    private IState<AppState> AppState { get; set; }

    [Inject]
    private IState<BoardState> BoardState { get; set; }

    [Inject]
    private IState<AdvertisementState> AdvertisementState { get; set; }

    public bool IsDrawerOpen => AppState.Value.IsDrawerOpen;

    public bool ShowLoadingSpinner => !BoardState.Value.IsInitialized || !AdvertisementState.Value.IsInitialized;
}
