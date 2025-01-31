using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{

    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<Book> CreateBookAsync(Book newBook)
    {
        await _bookService.CreateBookAsync(newBook);

        return newBook;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBookAsync(Guid bookId)
    {
        await _bookService.DeleteBookAsync(bookId);

        return NoContent();
    }

    [AllowAnonymous]
    [HttpGet("id:{bookId}")]
    public async Task<Book> GetBookByIdAsync(Guid bookId)
    {
        Book book = await _bookService.GetBookByIdAsync(bookId);

        return book;
    }

    [AllowAnonymous]
    [HttpGet("isbn:{bookIsbn}")]
    public async Task<Book> GetBookByIsbnAsync(string bookIsbn)
    {
        Book book = await _bookService.GetBookByIsbnAsync(bookIsbn);

        return book;
    }

    [AllowAnonymous]
    [HttpGet("title:{bookTitle}")]
    public async Task<List<Book>> GetBooksByTitleAsync(string bookTitle)
    {
        List<Book> books = await _bookService.GetBooksByTitleAsync(bookTitle);

        return books;
    }

    [AllowAnonymous]
    [HttpGet("author:{bookAuthor}")]
    public async Task<List<Book>> GetBooksByAuthorAsync(string bookAuthor)
    {
        List<Book> books = await _bookService.GetBooksByAuthorAsync(bookAuthor);

        return books;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{bookId}")]
    public async Task<Book> UpdateBookAsync(Guid bookId, Book updatedBook)
    {
        var book = await _bookService.UpdateBookAsync(bookId, updatedBook);

        return book;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _bookService.GetBooksAsync();
    }
}
