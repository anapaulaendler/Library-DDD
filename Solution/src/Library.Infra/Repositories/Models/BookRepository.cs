using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var book = await _dbSet.FindAsync(isbn);

        if (book is null)
        {
            throw new KeyNotFoundException();
        }

        return book;
    }

    public List<Book> GetBookByTitleAsync(string title)
    {
        List<Book> books = [];
        books = _dbSet.Where(x => x.Title == title).ToList();

        return books;
    }

    public List<Book> GetBooksByAuthorAsync(string author)
    {
        List<Book> books = [];
        books = _dbSet.Where(x => x.Author == author).ToList();

        return books;
    }
}