﻿using Fluxor;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.App.Store.Board;

[FeatureState]
[PersistState(PersistanceName = "circles-board")]
public record BoardState
{
    public bool? IsTileView { get; init; }
    internal string SearchString { get; init; }
    internal SortDirection SortDirection { get; init; } = SortDirection.Descending;
    internal SortColumn SortColumn { get; init; } = SortColumn.CreatedAt;

    public BoardState() { }
}