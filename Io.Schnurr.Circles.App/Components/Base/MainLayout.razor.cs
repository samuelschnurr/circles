using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class MainLayout
{
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            LoadStates();
        }
    }

    private void LoadStates()
    {
        Dispatcher.Dispatch(new AppStateLoadAction());
    }
}
