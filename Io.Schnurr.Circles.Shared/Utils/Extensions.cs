using System.ComponentModel.DataAnnotations;

namespace Io.Schnurr.Circles.App.Utils;

public static class Extensions
{
    public static string ToCurrency(this decimal? price) => price == null ? string.Empty : $"{price:N2} $";

    public static string[] SplitNewLines(this string text)
    {
        return text.Split("\n");
    }

    public static IEnumerable<T> Order<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector, bool ascending)
    {
        if (ascending)
        {
            return source.OrderBy(selector);
        }
        else
        {
            return source.OrderByDescending(selector);
        }
    }

    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var displayAttribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                                     .OfType<DisplayAttribute>()
                                     .FirstOrDefault();
        return displayAttribute?.Name ?? value.ToString();
    }

    public static double BytesToMegabytes(this long bytes)
    {
        const double bytesInMegabyte = 1024 * 1024;
        var mbResult = Math.Round(bytes / bytesInMegabyte, 3);

        return mbResult;
    }
}