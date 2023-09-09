using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class Image
{
    [Parameter]
    public string Base64Image { get; set; }
}
