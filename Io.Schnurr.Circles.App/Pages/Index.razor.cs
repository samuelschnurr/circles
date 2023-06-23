using Io.Schnurr.Circles.App.Interfaces;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    public bool IsLoading() => BoardState.Value.IsTileView == null;

    private bool ShowTileView() => BoardState.Value.IsTileView == true;
}
