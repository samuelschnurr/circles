namespace Io.Schnurr.Circles.App.Components.Base;

public partial class MainLayout
{
    private bool isDarkMode;
    private bool isDrawerOpen = true;

    private void DrawerToggle()
    {
        isDrawerOpen = !isDrawerOpen;
    }
}
