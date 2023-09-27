namespace Io.Schnurr.Circles.Shared.Models;

public abstract class Base
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
