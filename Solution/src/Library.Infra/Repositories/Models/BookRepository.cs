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
        var book = await _dbSet.FirstOrDefaultAsync(x => x.Isbn == isbn);

        if (book is null)
        {
            throw new KeyNotFoundException();
        }

        return book;
    }

    public async Task<List<Book>> GetBooksByTitleAsync(string title)
    {
        var books = await _dbSet
            .Where(b => b.Title.ToLower().Replace(" ", "").Contains(title.ToLower()))
            .ToListAsync();

        return books;
    }

    public async Task<List<Book>> GetBooksByAuthorAsync(string author)
    {
        var books = await _dbSet
            .Where(b => b.Author.ToLower().Replace(" ", "").Contains(author.ToLower()))
            .ToListAsync();
        
        return books;
    }
}
