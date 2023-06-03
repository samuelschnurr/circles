namespace Io.Schnurr.Circles.App.Pages;

public partial class Index
{
    public bool IsLoading() => true;// TODO

    private void OnIsTileViewChanged()
    {
        Dispatcher.Dispatch(new OnIsTileViewChangedAction());
    }

    private bool ShowTileView() => BoardState.Value.IsTileView;
}
