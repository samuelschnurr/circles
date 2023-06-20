namespace Io.Schnurr.Circles.App.Models;

public class PaperSwitchItem
{
    public PaperSwitchItem(string label, bool isChecked, bool isDisabled)
    {
        this.label = label;
        this.isChecked = isChecked;
        this.isDisabled = isDisabled;
    }

    internal readonly string label;
    internal bool isChecked;
    internal bool isDisabled;
}
