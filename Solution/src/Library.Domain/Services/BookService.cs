using Library.Domain.Interfaces;
using Library.Domain.Models;

namespace Library.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _uow;

    public BookService(IBookRepository bookRepository, IUnitOfWork uow)
    {
        _bookRepository = bookRepository;
        _uow = uow;
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

        return book;
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var book = await _bookRepository.GetBookByIsbnAsync(isbn);

        return book;
    }

    public async Task<List<Book>> GetBookByTitleAsync(string title)
    {
        var books = await _bookRepository.GetBookByTitleAsync(title);

        return books;
    }

    public async Task<List<Book>> GetBooksByAuthorAsync(string author)
    {
        var books = await _bookRepository.GetBooksByAuthorAsync(author);

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
}