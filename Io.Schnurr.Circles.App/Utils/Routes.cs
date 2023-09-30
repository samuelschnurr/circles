namespace Io.Schnurr.Circles.App.Utils;

internal abstract class Routes
{
    private const string DetailSegment = $"/{{Id:int}}";
    private const string FormSegment = $"/form/{{Id:int?}}";

    internal abstract class Base
    {
        internal const string Index = "/";
    }

    internal abstract class Circle
    {
        internal const string Index = "/circle";
    }

    internal abstract class Board
    {
        internal const string Index = "/board";
        internal const string Detail = $"{Index}{DetailSegment}";
        internal static string GetDetailPath(int id) => FormatDetailPath(Index, id);
    }

    internal abstract class Offer
    {
        internal const string Index = "/offer";
        internal const string Form = $"{Index}{FormSegment}";
        internal static string GetFormPath(int? id = null) => FormatFormPath(Index, id);
    }

    private static string FormatDetailPath(string page, int id) => string.Format($"{page}/{{0}}", id);
    private static string FormatFormPath(string page, int? id = null) => id == null ? $"{page}/form" : string.Format($"{page}/form/{{0}}", id);
}
