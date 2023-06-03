using Io.Schnurr.Circles.App.Store.App;
using Io.Schnurr.Circles.App.Store.Board;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class MainLayout
{
    protected override void OnInitialized()
    {
        LoadStates();
    }
    private void LoadStates()
    {
        Dispatcher.Dispatch(new OnLoadAppStateAction());
        Dispatcher.Dispatch(new OnLoadBoardStateAction());
    }
}
