using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

[FeatureState]
public record BoardState
{
    public bool? IsTileView { get; init; }

    public BoardState() { }
}