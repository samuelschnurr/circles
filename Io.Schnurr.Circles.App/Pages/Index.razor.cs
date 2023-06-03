using Io.Schnurr.Circles.App.Store.Board;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index
{
    public bool IsLoading() => true;// TODO

    private void OnIsTileViewChanged()
    {
        Dispatcher.Dispatch(new OnIsTileViewChangedAction());
        Dispatcher.Dispatch(new OnPersistBoardStateAction(BoardState.Value));
    }

    private bool ShowTileView() => BoardState.Value.IsTileView;
}
