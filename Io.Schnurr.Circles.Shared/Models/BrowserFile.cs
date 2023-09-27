using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Forms;

namespace Io.Schnurr.Circles.Shared.Models;

public class BrowserFile
{
    [JsonIgnore]
    public IBrowserFile File { get; set; }

    public string Name { get; set; }

    public long Size { get; set; }

    public string Base64File { get; set; }
}