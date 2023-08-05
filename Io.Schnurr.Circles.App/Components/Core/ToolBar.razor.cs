using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class ToolBar
{
    [Parameter]
    public SortColumn SortColumn { get; set; }

    [Parameter]
    public SortDirection SortDirection { get; set; }

    [Parameter]
    public EventCallback ToggleTileView { get; set; }

    [Parameter]
    public EventCallback<SortColumn> OnSortColumnChanged { get; set; }

    [Parameter]
    public EventCallback<SortDirection> OnSortDirectionChanged { get; set; }

    [Parameter]
    public EventCallback<string> OnSearchChanged { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    [Parameter]
    public string SearchString { get; set; }
}
