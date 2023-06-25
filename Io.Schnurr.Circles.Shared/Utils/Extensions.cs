namespace Io.Schnurr.Circles.App.Utils;

public static class Extensions
{
    public static string ToCurrency(this decimal price) => $"{price:N2} $";

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
}