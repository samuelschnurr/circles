using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    [ReducerMethod]
    public static BoardState SetState(BoardState state, SetState action) => action.state;

    [ReducerMethod(typeof(SetDefaultState))]
    public static BoardState SetDefaultState(BoardState state) => new BoardState() with { IsTileView = true };
}

public class SetDefaultState { }