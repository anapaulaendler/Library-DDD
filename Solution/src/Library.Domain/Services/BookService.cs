using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Library.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMemoryCache _cache;
    private readonly IUnitOfWork _uow;

    public BookService(IBookRepository bookRepository, IUnitOfWork uow, IMemoryCache cache)
    {
        _bookRepository = bookRepository;
        _uow = uow;
        _cache = cache;
    }

    public async Task CreateBookAsync(Book book)
    {
        await _uow.BeginTransactionAsync();

        var newBook = new Book
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Isbn = book.Isbn,
            Genre = book.Genre,
            PublicationYear = book.PublicationYear
        };

        await _bookRepository.AddAsync(newBook);
        await _uow.CommitTransactionAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        await _uow.BeginTransactionAsync();

        var book = await GetBookByIdAsync(id);

        await _bookRepository.Delete(book);
        await _uow.CommitTransactionAsync();
    }

    public async Task<Book> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            throw new ArgumentException($"Book with ID {id} does not exist.");
        }

        return book;
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var book = await _bookRepository.GetBookByIsbnAsync(isbn);

        if (book is null)
        {
            throw new ArgumentException($"Book with ISBN {isbn} does not exist.");
        }

        return book;
    }

    public async Task<List<Book>> GetBooksByTitleAsync(string title)
    {
        var books = await _bookRepository.GetBooksByTitleAsync(title);

        if (books is null)
        {
            throw new ArgumentException($"Books with Title {title} do not exist.");
        }

        return books;
    }

    public async Task<List<Book>> GetBooksByAuthorAsync(string author)
    {
        var books = await _bookRepository.GetBooksByAuthorAsync(author);

        if (books is null)
        {
            throw new ArgumentException($"Books with Author {author} do not exist.");
        }

        return books;
    }

    public async Task<Book> UpdateBookAsync(Guid id, Book updatedBook)
    {
        await _uow.BeginTransactionAsync();

        var book = await GetBookByIdAsync(id);

        book.Title = updatedBook.Title;
        book.Isbn = updatedBook.Isbn;
        book.Genre = updatedBook.Genre;

        await _bookRepository.Update(book);
        await _uow.CommitTransactionAsync();

        return book;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        const string cacheKey = "Books";
        if (!_cache.TryGetValue(cacheKey, out List<Book>? books))
        {
            books = await _bookRepository.GetAsync();

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            _cache.Set(cacheKey, books, cacheOptions);
        }

        return books ?? new List<Book>();
    }
}