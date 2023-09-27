using Microsoft.AspNetCore.Components.Forms;

namespace Io.Schnurr.Circles.Shared.Models;

public class BrowserFile : IBrowserFile
{
    public string Name { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public long Size { get; set; }

    public string ContentType { get; set; }

    public string Base64File { get; set; }

    public Stream OpenReadStream(long maxAllowedSize = 512000, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}