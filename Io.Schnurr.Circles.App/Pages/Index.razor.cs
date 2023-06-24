using Io.Schnurr.Circles.App.Interfaces;
using Io.Schnurr.Circles.App.Store.Board;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    public bool IsLoading => BoardState.Value.IsTileView == null;

    private bool ShowTileView => BoardState.Value.IsTileView == true;

    private void HandleToggleTileView()
    {
        Dispatcher.Dispatch(new UpdateStateAction(BoardState.Value with { IsTileView = !BoardState.Value.IsTileView }));
    }

    private async Task HandleSearch(string s)
    {
        // TODO Codebehind
        Console.WriteLine("You searched: " + s);
        await Task.FromResult(0);
    }
}
