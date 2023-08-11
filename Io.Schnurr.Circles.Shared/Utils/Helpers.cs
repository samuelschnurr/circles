namespace Io.Schnurr.Circles.App.Utils;

public static class Helpers
{
    public static bool HasNull(params dynamic?[] nullableValues)
    {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
        foreach (var value in nullableValues)
        {
            if (value is null)
            {
                return true;
            }
        }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
        return false;
    }
}