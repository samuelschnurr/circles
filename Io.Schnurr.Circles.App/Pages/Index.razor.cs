﻿using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
namespace Io.Schnurr.Circles.App.Pages;

public partial class Index
{
    [Inject]
    private AdvertisementService AdvertisementService { get; init; }

    private IEnumerable<Advertisement>? advertisements;

    private SortColumn SortColumn => BoardState.Value.SortColumn;

    private SortDirection SortDirection => BoardState.Value.SortDirection;

    public bool IsLoading => BoardState.Value.IsTileView == null;

    private bool ShowTileView => BoardState.Value.IsTileView == true;

    protected override async Task OnInitializedAsync()
    {
        await LoadAdvertisements();
    }

    private async Task LoadAdvertisements()
    {
        advertisements = null;
        var searchString = BoardState.Value.SearchString;
        var data = await AdvertisementService.GetAll(true, searchString);
        advertisements = AdvertisementService.SortAdvertisements(data, SortColumn, SortDirection);
    }

    private void SortAdvertisements()
    {
        advertisements = AdvertisementService.SortAdvertisements(advertisements, SortColumn, SortDirection);
    }

    private void ToggleTileView()
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));
    }
}
