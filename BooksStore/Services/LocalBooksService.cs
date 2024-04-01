using BooksStore.Models;

namespace BooksStore.Services;

public class LocalBooksService : IBooksService
{
    private static readonly List<Book> _allBooks =
    [
        new Book
        {
            Id = Guid.NewGuid().ToString(),
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2021, 01, 12),
            Title = "Blazor WebAssembly Guide",
            Description = "Test",
            Price = 10000
        },

        new Book
        {
            Id = Guid.NewGuid().ToString(),
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2022, 03, 13),
            Title = "Mastering Blazor WebAssembly"
        },

        new Book
        {
            Id = Guid.NewGuid().ToString(),
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2022, 08, 01),
            Title = "Learning Blazor from A to Z"
        }
    ];

    public Task<List<Book>> GetAllBooksAsync()
    {
        return Task.FromResult(_allBooks);
    }

    public Task<Book?> GetBookByIdAsync(string? id)
    {
        var book = _allBooks.SingleOrDefault(b => b.Id == id);
        return Task.FromResult(book);
    }
}