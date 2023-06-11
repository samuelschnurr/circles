using Io.Schnurr.Circles.App.Interfaces;
using Io.Schnurr.Circles.App.Store.Board;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    public bool IsLoading() => BoardState.Value.IsTileView == null;

    private void ToggleTileView()
    {
        Dispatcher.Dispatch(new SetState(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));
        Dispatcher.Dispatch(new PersistState());
    }

    private bool ShowTileView() => BoardState.Value.IsTileView == true;
}
