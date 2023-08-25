using Fluxor;
using Io.Schnurr.Circles.App.Features.Board.Store;
using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Features.Board.Views;

public partial class BoardToolBar
{
    [Inject]
    private IState<BoardState> BoardState { get; set; }

    private SortColumn SortColumn => BoardState.Value.SortColumn;

    private SortDirection SortDirection => BoardState.Value.SortDirection;

    private string SearchString => BoardState.Value.SearchString;

    private bool ShowTileView => BoardState.Value.IsTileView;

    private void ToggleTileView() => Dispatcher.Dispatch(new ToggleTileViewAction());

    private void OrderBySortColumn(SortColumn column) => Dispatcher.Dispatch(new OrderBySortColumnAction(column));

    private void OrderBySortDirection(SortDirection direction) => Dispatcher.Dispatch(new OrderBySortDirectionAction(direction));

    private void SearchByString(string search) => Dispatcher.Dispatch(new SearchByStringAction(search));
}
