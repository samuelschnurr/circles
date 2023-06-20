using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class PaperSwitch
{
    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool Checked { get; set; }
}
