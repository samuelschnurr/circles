using Fluxor;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Store.Board;

[FeatureState]
public record BoardState
{
    public bool? IsTileView { get; init; }

    internal string SearchString { get; init; }

    internal SortDirection SortDirection { get; init; } = SortDirection.Descending;

    internal SortColumn SortColumn { get; init; } = SortColumn.CreatedAt;

    public BoardState() { }
}