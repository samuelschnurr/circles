using Fluxor;
using Io.Schnurr.Circles.App.Features.Board.Store;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using static Io.Schnurr.Circles.App.Features.Board.Store.BoardActions;

namespace Io.Schnurr.Circles.App.Features.Board.Views;

public partial class BoardData
{
    [Inject]
    private IState<BoardState> BoardState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<Advertisement> Data => GetAdvertisements();

    public bool ShowTileView => BoardState.Value.IsTileView;

    public bool ShowLoadingSpinner => !BoardState.Value.IsReady;

    protected override async Task OnInitializedAsync()
    {
        Dispatcher.Dispatch(new LoadAdvertisementsAction());
        await Task.CompletedTask;
    }

    private IEnumerable<Advertisement> GetAdvertisements()
    {
        var advertisements = BoardState.Value.Items;
        var filteredAdvertisements = AdvertisementService.FilterAdvertisements(advertisements, BoardState.Value.SearchString);
        var filteredAndSortedAdvertisements = AdvertisementService.SortAdvertisements(filteredAdvertisements, BoardState.Value.SortColumn, BoardState.Value.SortDirection);
        return filteredAndSortedAdvertisements;
    }

    private void NavigateToBoardDetail(int id) => NavigationManager.NavigateTo(Routes.Board.GetDetailPath(id));
}
