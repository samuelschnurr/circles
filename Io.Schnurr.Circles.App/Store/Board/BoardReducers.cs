using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    [ReducerMethod]
    public static BoardState SetState(BoardState state, SetStateAction action) => action.state;
}

public record SetStateAction(BoardState state) { }