using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Shared;

public partial class NavMenuItem
{
    [Parameter, EditorRequired]
    public Models.NavMenuItem? Item { get; init; }
}