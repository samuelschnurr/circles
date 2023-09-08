using Io.Schnurr.Circles.App.Utils;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class TextArea
{
    [Parameter]
    public string Text { get; set; }

    public string[] TextParagraphs => Text.SplitNewLines();
}