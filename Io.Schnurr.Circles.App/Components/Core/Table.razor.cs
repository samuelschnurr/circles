using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class Table<T>
{
    [Parameter]
    public IEnumerable<T> Data { get; set; }

    [Parameter]
    public RenderFragment<T> TableRowTemplate { get; set; }

    [Parameter]
    public string[] TableHeaders { get; set; }
}
