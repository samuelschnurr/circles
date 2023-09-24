using System.Linq.Expressions;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class FileUpload
{
    [Parameter]
    public BrowserFile BrowserFile { get; set; }

    [Parameter]
    public Expression<Func<IBrowserFile>> For { get; set; }

    private string FileDisplayString => BrowserFile?.File == null ? string.Empty : $"{BrowserFile?.File?.Name} ({BrowserFile?.File?.Size.BytesToMegabytes()} Mb)";

    private async Task SetFile(InputFileChangeEventArgs args)
    {
        var file = args.File;

        using var ms = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(ms);
        var bytes = ms.ToArray();
        var base64File = Convert.ToBase64String(bytes);
        BrowserFile.Base64File = base64File;
    }
}