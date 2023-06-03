using Fluxor;

namespace Io.Schnurr.Circles.App.Store;

[FeatureState]
public record BoardState
{
    public bool IsTileView { get; init; } = true;

    public BoardState() { }
}

public static class BoardReducer
{
    [ReducerMethod(typeof(OnIsTileViewChangedAction))]
    public static BoardState HandleIsTileViewChangedAction(BoardState state) => state with { IsTileView = !state.IsTileView };
}

public class OnIsTileViewChangedAction { }