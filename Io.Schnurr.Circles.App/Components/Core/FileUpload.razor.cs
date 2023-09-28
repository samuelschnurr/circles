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

    private string FileDisplayString => string.IsNullOrEmpty(BrowserFile?.Name) ? string.Empty : $"{BrowserFile?.Name} ({BrowserFile?.Size.BytesToMegabytes()} Mb)";

    private bool IsUploadingFile = false;

    private async Task SetFile(IBrowserFile file)
    {
        IsUploadingFile = true;
        BrowserFile.Name = file.Name;
        BrowserFile.Size = file.Size;
        BrowserFile.LastModified = file.LastModified;
        BrowserFile.ContentType = file.ContentType;

        try
        {
            using var ms = new MemoryStream();
            // 2,5 MB maximum per file as mentioned in validator
            await file.OpenReadStream(Helpers.MaxFileSize).CopyToAsync(ms);
            var bytes = ms.ToArray();
            var base64Content = await Helpers.ConvertBytesToBase64Async(bytes, file.ContentType);
            BrowserFile.Base64Content = base64Content;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            IsUploadingFile = false;
        }
    }
}