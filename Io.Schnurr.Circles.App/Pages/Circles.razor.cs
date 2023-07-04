namespace Io.Schnurr.Circles.App.Pages;

public partial class Circles
{
    internal (string label, bool isChecked, bool isDisabled, bool isReadOnly)[] circles =
    {
        ("Work", true, false, true),
        ("Family", false, true, true),
        ("Friends", false, true, true)
    };
}
