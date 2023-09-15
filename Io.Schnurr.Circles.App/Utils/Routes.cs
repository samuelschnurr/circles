namespace Io.Schnurr.Circles.App.Utils;

internal abstract class Routes
{
    internal abstract class Base
    {
        internal const string Index = "/";
    }

    internal abstract class Board
    {
        internal const string Index = "/board";
        internal const string Detail = $"{Index}/{{Id:int}}";
        internal static string GetDetailPath(int id) => string.Format($"{Index}/{{0}}", id);
    }

    internal abstract class Circle
    {
        internal const string Index = "/circle";
    }

    internal abstract class Offer
    {
        internal const string Index = "/offer";
        internal const string Detail = $"{Index}/{{Id:int}}";
        internal static string GetDetailPath(int id) => string.Format($"{Index}/{{0}}", id);
    }
}
