using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class EnumSelect<T> where T : Enum
{
    [Parameter]
    public T SelectedValue { get; set; }

    [Parameter]
    public EventCallback<T> OnSelectedValueChanged { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int MinWidth { get; set; } = 150;
}
