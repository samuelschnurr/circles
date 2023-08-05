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

    public string SearchString
    {
        get => BoardState.Value.SearchString;
        set => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SearchString = value }, OnSearch));
    }

    private void OnSortColumnChanged(SortColumn column)
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortColumn = column }, OnSort));
    }

    private void OnSortDirectionChanged(SortDirection direction)
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortDirection = direction }, OnSort));
    }
}
