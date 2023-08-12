using Fluxor;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Store.Board;

public static class BoardReducer
{
    [ReducerMethod(typeof(ToggleTileViewAction))]
    public static BoardState ToggleTileView(BoardState state) => state with { IsTileView = !state.IsTileView };

    [ReducerMethod]
    public static BoardState OrderBySortColumn(BoardState state, OrderBySortColumnAction action) => state with { SortColumn = action.SortColumn };

    [ReducerMethod]
    public static BoardState OrderBySortDirection(BoardState state, OrderBySortDirectionAction action) => state with { SortDirection = action.SortDirection };

    [ReducerMethod]
    public static BoardState SearchByString(BoardState state, SearchByStringAction action) => state with { SearchString = action.Search };

    [ReducerMethod(typeof(SetDefaultStateAction))]
    public static BoardState SetDefaultState(BoardState state) => new() { IsTileView = true };

    [ReducerMethod]
    public static BoardState SetStateFromLocalStorage(BoardState state, SetStateFromLocalStorageAction action) => action.State;
}

[PersistAfterDispatch]
public record ToggleTileViewAction();

public record OrderBySortColumnAction(SortColumn SortColumn);

public record OrderBySortDirectionAction(SortDirection SortDirection);

public record SearchByStringAction(string Search);

[PersistAfterDispatch]
public record SetDefaultStateAction();

public record SetStateFromLocalStorageAction(BoardState State);