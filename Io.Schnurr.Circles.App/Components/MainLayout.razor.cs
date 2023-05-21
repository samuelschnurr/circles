namespace Io.Schnurr.Circles.App.Shared;

public partial class MainLayout
{
    private bool isDarkMode = false;
    private bool isDrawerOpen = true;

    private void drawerToggle()
    {
        isDrawerOpen = !isDrawerOpen;
    }
}
