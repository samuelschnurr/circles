using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.UserInterface;

public partial class EnumSelect<T> where T : Enum
{
    [Parameter]
    public T SelectedValue { get; set; }

    [Parameter]
    public EventCallback<T> OnSelectedValueChanged { get; set; }

    [Parameter]
    public Expression<Func<T>>? For { get; set; }

    [Parameter]
    public bool Immediate { get; set; } = false;

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int MinWidth { get; set; } = 150;

    [Parameter]
    public string? Class { get; set; }
}
