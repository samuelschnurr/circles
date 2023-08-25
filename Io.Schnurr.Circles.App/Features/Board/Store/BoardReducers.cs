using Fluxor;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Features.Board.Store;

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

    [ReducerMethod]
    public static BoardState SetAdvertisements(BoardState state, SetAdvertisementsAction action) => state with { Items = action.Advertisements };

    [ReducerMethod]
    public static BoardState SetBoardStateIsLoading(BoardState state, SetBoardStateIsLoadingAction action) => state with { IsLoading = action.IsLoading };
}

public record ToggleTileViewAction();
public record OrderBySortColumnAction(SortColumn SortColumn);
public record OrderBySortDirectionAction(SortDirection SortDirection);
public record SearchByStringAction(string Search);
public record SetAdvertisementsAction(IEnumerable<Shared.Models.Advertisement> Advertisements);
public record SetBoardStateIsLoadingAction(bool IsLoading);