using BooksStore.Blazor.Components;
using BooksStore.Models;

namespace BooksStore.Pages;

public partial class BookForm
{
    private SubmitBook? _book = new();
    private TimeOnly _time = new(12, 30, 0);
    private BlazorSimpleMde? _simpleMde;

    private async Task HandleBookFormSubmission()
    {
        _book!.Description = await _simpleMde?.GetEditorValueAsync()!;
        Console.WriteLine("Book has been submitted successfully");
        Console.WriteLine($"Title {_book.Title}");
        Console.WriteLine($"Author {_book.Author}");
        Console.WriteLine($"Price ${_book.Price}");
        await ClearSavedStateAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        SetupTimer();
        await CheckSavedStateAsync();
    }

    private async Task SaveFormStateAsync()
    {
        // Read the description from the SimpleMDE editor
        _book!.Description = await _simpleMde!.GetEditorValueAsync();
        // SaveItemAsync takes a key which is the 'book' and the value to store, it will be serialized and stored as JSON object
        await LocalStorage.SetItemAsync("book", _book);
    }

    private async Task CheckSavedStateAsync()
    {
        if (await LocalStorage.ContainKeyAsync("book"))
        {
            _book = await LocalStorage.GetItemAsync<SubmitBook>("book");
        }
    }

    private async Task ClearSavedStateAsync() => await LocalStorage.RemoveItemAsync("book");

    private readonly System.Timers.Timer _timer = new();

    private void SetupTimer()
    {
        const int second = 1000;
        _timer.Interval = 10 * second;
        _timer.Elapsed += async (sender, e) => { await SaveFormStateAsync(); };
        _timer.Start();
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
    }
}