using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    // Better would be to create separate reducers or effects for each action
    // This would improve state tracing in DevTools, clean accessing of state transformation methods instead of access in components and more
    // But for simplification reasons in this prototype I use a single SetState reducer
    [ReducerMethod]
    public static BoardState SetState(BoardState state, SetStateAction action) => action.state;
}

public record SetStateAction(BoardState state) : PersistAfterDispatchAction<BoardState>(state);