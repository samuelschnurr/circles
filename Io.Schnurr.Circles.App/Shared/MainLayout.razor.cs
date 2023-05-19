namespace Io.Schnurr.Circles.App.Shared;

public partial class MainLayout
{
    private bool isDarkMode = false;
    private bool drawerOpen = true;

    private void drawerToggle()
    {
        drawerOpen = !drawerOpen;
    }
}
