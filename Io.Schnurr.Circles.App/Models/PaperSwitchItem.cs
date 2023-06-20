namespace Io.Schnurr.Circles.App.Models;

public class PaperSwitchItem
{
    public PaperSwitchItem(string label, bool isChecked, bool isDisabled, bool isReadOnly)
    {
        this.label = label;
        this.isChecked = isChecked;
        this.isDisabled = isDisabled;
        this.isReadOnly = isReadOnly;
    }

    internal readonly string label;
    internal readonly bool isChecked;
    internal readonly bool isDisabled;
    internal readonly bool isReadOnly;
}
