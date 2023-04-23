using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Shared.Navigation;

public partial class NavMenuItem
{
    [Parameter, EditorRequired]
    public Models.NavMenuItem? Item { get; init; }
}