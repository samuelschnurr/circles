using Fluxor;
using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Views.Advertisements;

public partial class AdvertisementToolBar
{
    [Inject]
    private IState<BoardState> BoardState { get; set; }

    private SortColumn SortColumn => BoardState.Value.SortColumn;

    private SortDirection SortDirection => BoardState.Value.SortDirection;

    private string SearchString => BoardState.Value.SearchString;

    private bool ShowTileView => BoardState.Value.IsTileView == true;

    private void ToggleTileView() => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));

    private void OrderBySortColumn(SortColumn column) => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortColumn = column }));

    private void OrderBySortDirection(SortDirection direction) => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortDirection = direction }));

    private void SearchByString(string search) => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SearchString = search }));
}
