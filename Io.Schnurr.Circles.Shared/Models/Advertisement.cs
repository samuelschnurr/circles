using Io.Schnurr.Circles.Shared.Enums;

namespace Io.Schnurr.Circles.Shared.Models;

public class Advertisement : Base
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CreatedBy { get; set; }
    public AdvertisementCondition Condition { get; set; }
    public File Image { get; set; }
}
