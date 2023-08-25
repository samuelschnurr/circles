using Fluxor;
using Io.Schnurr.Circles.App.Features.App.Store;
using Io.Schnurr.Circles.App.Features.Board.Store;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Features.Board.Views;

public partial class BoardIndex
{
    [Inject]
    private IState<AppState> AppState { get; set; }

    [Inject]
    private IState<BoardState> BoardState { get; set; }

    public bool IsDrawerOpen => AppState.Value.IsDrawerOpen;

    public bool ShowLoadingSpinner => !BoardState.Value.IsInitialized;
}
