namespace Io.Schnurr.Circles.Shared.Models;

public abstract class Base
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? DeletedAt { get; init; }
}
