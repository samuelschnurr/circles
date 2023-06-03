using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    [ReducerMethod(typeof(OnIsTileViewChangedAction))]
    public static BoardState HandleIsTileViewChangedAction(BoardState state) => state with { IsTileView = !state.IsTileView };

    [ReducerMethod]
    public static BoardState HandleSetBoardState(BoardState state, OnSetBoardStateAction action) => action.BoardState;
}


public class OnIsTileViewChangedAction { }