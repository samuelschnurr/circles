using Fluxor;
using Io.Schnurr.Circles.App.Store.Advertisement;
using Io.Schnurr.Circles.App.Store.App;
using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Views.Advertisements;

public partial class AdvertisementOverview
{
    [Inject]
    private IState<AdvertisementState> AdvertisementState { get; set; }

    [Inject]
    private IState<AppState> AppState { get; set; }

    [Inject]
    private IState<BoardState> BoardState { get; set; }

    private IEnumerable<Advertisement>? Data => AdvertisementState.Value.Items;

    public bool IsDrawerOpen => AppState.Value.IsDrawerOpen;

    public bool? ShowTileView => BoardState.Value.IsTileView;

    public bool IsLoading => Helpers.HasNull(Data, ShowTileView);
}
