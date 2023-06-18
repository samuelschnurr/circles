namespace Io.Schnurr.Circles.App.Utils;

public static class Formatter
{
    public static string ToCurrency(this decimal price) => $"{price:N2} $";
}