using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IBookService
{
    Task CreateBookAsync(Book book);
    Task<Book> GetBookByIdAsync(Guid id);
    Task<List<Book>> GetBookByTitleAsync(string title);
    Task<List<Book>> GetBooksByAuthorAsync(string author);
    Task<Book> GetBookByIsbnAsync(string isbn);
    Task<Book> UpdateBookAsync(Guid id, Book book);
    Task DeleteBookAsync(Guid id); // depois, lembrar que aqui só diminui um da quantity, se a quantity < 1 deleta.
}