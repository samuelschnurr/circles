using Io.Schnurr.Circles.App.Interfaces;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    [Inject]
    private AdvertisementService AdvertisementService { get; init; }

    private IEnumerable<Advertisement>? advertisements;

    public bool IsLoading => advertisements == null;

    private bool ShowTileView => BoardState.Value.IsTileView == true;

    protected override async Task OnInitializedAsync()
    {
        var data = await AdvertisementService.GetAll(true);
        advertisements = data;
    }

    private async Task SearchAdvertisements(string searchString)
    {
        var data = await AdvertisementService.GetAll(true, searchString);
        advertisements = data;
    }

    private void ToggleTileView()
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));
    }
}
