namespace Io.Schnurr.Circles.App.MemoryStorage;

public class AppState
{
    public bool isLoading;

    public bool IsLoading
    {
        get => isLoading;
        set
        {
            isLoading = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

}
