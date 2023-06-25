using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;
public partial class AdvertisementToolBar
{
    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    [Parameter]
    public EventCallback OnSort { get; set; }

    [Parameter]
    public EventCallback ToggleTileView { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    public SortDirection SortDirection
    {
        get => BoardState.Value.SortDirection;
        set => Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { SortDirection = value }, OnSort));
    }
}
