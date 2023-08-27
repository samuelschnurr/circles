using Fluxor;
using Io.Schnurr.Circles.App.Features.Board.Store;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Features.Board.Views;

public partial class BoardIndex
{
    [Inject]
    private IState<BoardState> BoardState { get; set; }

    public bool ShowLoadingSpinner => !BoardState.Value.IsInitialized;
}
