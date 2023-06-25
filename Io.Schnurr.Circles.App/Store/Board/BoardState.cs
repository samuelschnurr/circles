using Fluxor;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Store.Board;

[FeatureState]
public record BoardState
{
    public bool? IsTileView { get; init; }

    public SortDirection? SortDirection { get; init; }

    public BoardState() { }
}