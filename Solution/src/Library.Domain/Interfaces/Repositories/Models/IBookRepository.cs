using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    Task<List<Book>> GetBookByTitleAsync(string title);
    Task<List<Book>> GetBooksByAuthorAsync(string author);
    Task<Book> GetBookByIsbnAsync(string isbn);
}