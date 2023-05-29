namespace Io.Schnurr.Circles.App.Components.Base;

public partial class MainLayout
{
    // TODO State
    private bool isDarkMode;
    private bool isDrawerOpen = true;

    private void DrawerToggle()
    {
        isDrawerOpen = !isDrawerOpen;
    }
}