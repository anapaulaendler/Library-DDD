using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    List<Book> GetBookByTitleAsync(string title);
    List<Book> GetBooksByAuthorAsync(string author);
    Task<Book> GetBookByIsbnAsync(string isbn);
}