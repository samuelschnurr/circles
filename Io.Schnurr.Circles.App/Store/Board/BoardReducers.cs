using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    [ReducerMethod]
    public static BoardState SetBoardState(BoardState state, SetBoardState action) => action.BoardState;

    [ReducerMethod(typeof(SetDefaultBoardState))]
    public static BoardState SetDefaultBoardState(BoardState state) => new BoardState() with { IsTileView = true };
}

public class SetDefaultBoardState { }