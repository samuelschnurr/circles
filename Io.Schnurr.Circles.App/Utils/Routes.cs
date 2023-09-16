namespace Io.Schnurr.Circles.App.Utils;

internal abstract class Routes
{
    private const string detailSegment = $"/{{Id:int}}";
    private const string formSegment = $"/form/{{Id:int?}}";

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
        internal const string Detail = $"{Index}{detailSegment}";
        internal static string GetDetailPath(int id) => FormatDetailPath(Index, id);
    }

    internal abstract class Offer
    {
        internal const string Index = "/offer";
        internal const string Form = $"{Index}{formSegment}";
        internal static string GetFormPath(int? id = null) => FormatFormPath(Index, id);
    }

    private static string FormatDetailPath(string index, int id) => string.Format($"{index}/{{0}}", id);
    private static string FormatFormPath(string index, int? id = null) => id == null ? $"{index}/form" : string.Format($"{index}/form/{{0}}", id);
}
