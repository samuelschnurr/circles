namespace Io.Schnurr.Circles.App.Features.Circle.Views;

public partial class CircleIndex
{
    internal (string label, bool isChecked, bool isDisabled, bool isReadOnly)[] circles =
    {
        ("Work", true, false, true),
        ("Family", false, true, true),
        ("Friends", false, true, true)
    };
}
