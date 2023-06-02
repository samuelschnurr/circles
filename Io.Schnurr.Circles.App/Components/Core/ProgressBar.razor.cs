namespace Io.Schnurr.Circles.App.Components.Core;

public partial class ProgressBar
{
    private string GetCenterCircularStyle()
    {
        string centerCircularStyle = "height: calc(100vh - 176px);";

        if (false)
        {
            centerCircularStyle += "width: calc(100% var(--mud-drawer-width,var(--mud-drawer-width-left)));";
        }

        return centerCircularStyle;
    }
}
