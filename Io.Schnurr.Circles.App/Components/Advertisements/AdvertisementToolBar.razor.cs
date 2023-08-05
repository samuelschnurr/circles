using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;
public partial class AdvertisementToolBar
{
    [Parameter]
    public EventCallback OnSearch { get; set; }

    [Parameter]
    public EventCallback OnSort { get; set; }

    [Parameter]
    public EventCallback ToggleTileView { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    public SortColumn SortColumn
    {
        get => BoardState.Value.SortColumn;
        set => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortColumn = value }, OnSort));
    }

    public SortDirection SortDirection
    {
        get => BoardState.Value.SortDirection;
        set => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortDirection = value }, OnSort));
    }

    public string SearchString
    {
        get => BoardState.Value.SearchString;
        set => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SearchString = value }, OnSearch));
    }
}
