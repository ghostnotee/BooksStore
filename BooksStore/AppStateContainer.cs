namespace BooksStore;

public class AppStateContainer
{
    public int CurrentCounter { get; private set; }

    public Action<int>? OnCounterChanged { get; set; }

    public void UpdateCounter(int newCounter)
    {
        CurrentCounter = newCounter;
        OnCounterChanged?.Invoke(newCounter);
    }
}