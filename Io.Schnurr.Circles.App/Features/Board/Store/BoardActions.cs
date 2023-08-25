using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Features.Board.Store;

public abstract class BoardActions
{
    public record LoadAdvertisementsAction();
    public record ToggleTileViewAction();
    public record OrderBySortColumnAction(SortColumn SortColumn);
    public record OrderBySortDirectionAction(SortDirection SortDirection);
    public record SearchByStringAction(string Search);
    public record SetAdvertisementsAction(IEnumerable<Shared.Models.Advertisement> Advertisements);
    public record SetBoardStateIsLoadingAction(bool IsLoading);
}
