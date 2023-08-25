namespace Io.Schnurr.Circles.App.Utils;

internal abstract class Routes
{
    internal abstract class Index
    {
        internal const string Base = "/";
    }

    internal abstract class Circles
    {
        internal const string Base = "/circles";
    }

    internal abstract class Pins
    {
        internal const string Base = "/pins";
    }

    internal abstract class Advertisement
    {
        internal const string Base = "/advertisement";
        internal const string Details = $"{Base}/{{Id:int}}";
        internal static string GetDetailsPath(int id) => string.Format($"{Base}/{{0}}", id);
    }
}
