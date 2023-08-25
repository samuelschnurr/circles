namespace Io.Schnurr.Circles.App.Features.Circles.Views;

public partial class CirclesIndex
{
    internal (string label, bool isChecked, bool isDisabled, bool isReadOnly)[] circles =
    {
        ("Work", true, false, true),
        ("Family", false, true, true),
        ("Friends", false, true, true)
    };
}
