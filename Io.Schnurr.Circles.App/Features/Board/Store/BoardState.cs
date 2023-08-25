using Fluxor;
using Io.Schnurr.Circles.App.Features.Base.Store;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Features.Board.Store;

[FeatureState]
[PersistState("circles-board")]
public record BoardState : BaseState
{
    public bool IsTileView { get; init; } = true;
    internal IEnumerable<Shared.Models.Advertisement> Items { get; init; }
    internal string SearchString { get; init; }
    internal SortDirection SortDirection { get; init; } = SortDirection.Descending;
    internal SortColumn SortColumn { get; init; } = SortColumn.CreatedAt;

    public BoardState() { }
}