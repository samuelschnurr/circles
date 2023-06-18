namespace Io.Schnurr.Circles.Shared.Models;

public class Offer : Base
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public File Image { get; set; }
}
