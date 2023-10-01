using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.UserInterface;

public partial class Image
{
    [Parameter]
    public string Base64Image { get; set; }
}
