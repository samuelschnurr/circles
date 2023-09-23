using Microsoft.AspNetCore.Components.Forms;

namespace Io.Schnurr.Circles.Shared.Models;

public class BrowserFile
{
    public IBrowserFile File { get; set; }
    public string Base64File { get; set; }
}