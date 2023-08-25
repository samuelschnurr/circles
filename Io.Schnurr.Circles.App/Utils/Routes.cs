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

    internal abstract class Circles
    {
        internal const string Index = "/circles";
    }

    internal abstract class Pins
    {
        internal const string Index = "/pins";
    }
}
