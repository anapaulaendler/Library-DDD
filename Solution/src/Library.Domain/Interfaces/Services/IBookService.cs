using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IBookService
{
    Task CreateBookAsync(Book book);
    Task<Book> GetBookByIdAsync(Guid id);
    List<Book> GetBookByTitleAsync(string title);
    List<Book> GetBooksByAuthorAsync(string author);
    Task<Book> GetBookByIsbnAsync(string isbn);
    Task<Book> UpdateBookAsync(Guid id, Book updatedBook);
    Task DeleteBookAsync(Guid id); 
}