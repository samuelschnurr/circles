using Io.Schnurr.Circles.App.Store.Board;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Board;
public partial class BoardToolBar
{
    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    private void ToggleTileView()
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));
    }
}
