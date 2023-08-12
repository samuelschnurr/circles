using Fluxor;
using Io.Schnurr.Circles.App.Services;
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

    private IEnumerable<Advertisement>? Data => GetAdvertisements();

    public bool IsDrawerOpen => AppState.Value.IsDrawerOpen;

    public bool? ShowTileView => BoardState.Value.IsTileView;

    public bool IsLoading => Helpers.HasNull(Data, ShowTileView);

    protected override async Task OnInitializedAsync()
    {
        Dispatcher.Dispatch(new LoadAdvertisementsAction());
        await Task.CompletedTask;
    }

    private IEnumerable<Advertisement>? GetAdvertisements()
    {
        var advertisements = AdvertisementState.Value.Items;
        var filteredAdvertisements = AdvertisementService.FilterAdvertisements(advertisements, BoardState.Value.SearchString);
        var filteredAndSortedAdvertisements = AdvertisementService.SortAdvertisements(filteredAdvertisements, BoardState.Value.SortColumn, BoardState.Value.SortDirection);
        return filteredAndSortedAdvertisements;
    }
}
