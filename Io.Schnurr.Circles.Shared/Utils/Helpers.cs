namespace Io.Schnurr.Circles.App.Utils;

public static class Helpers
{
    public static bool HasNull(params dynamic?[] nullableValues)
    {
        foreach (var value in nullableValues)
        {
            if (value is null)
            {
                return true;
            }
        }
        return false;
    }
}