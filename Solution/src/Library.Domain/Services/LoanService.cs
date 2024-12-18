using Library.Domain.Interfaces;
using Library.Domain.Models;

namespace Library.Domain.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;

    public LoanService(IUnitOfWork uow, IUserRepository userRepository, IBookRepository bookRepository, ILoanRepository loanRepository)
    {
        _uow = uow;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
    }

    public async Task<List<Loan>> GetLoansAsync()
    {
        var loans = await _loanRepository.GetAsync();

        return loans;
    }

    public async Task<List<Loan>> GetLoansByBookAsync(Guid bookId)
    {
        await ValidateBookAsync(bookId);

        var bookLoans = await _loanRepository.GetLoansByBookAsync(bookId);

        return bookLoans;
    }

    public async Task<List<Loan>> GetLoansByUserAsync(Guid userId)
    {
        await ValidateUserAsync(userId);

        var userLoans = await _loanRepository.GetLoansByUserAsync(userId);

        return userLoans;
    }

    public async Task<string> GetUserTotalFineAsync(Guid userId)
    {
        User user = await ValidateUserAsync(userId);

        decimal totalFine = await _loanRepository.GetUserTotalFineAsync(userId);

        return $"{user.Name}: $ {totalFine}";
    }

    public async Task<Loan> NewLoanAsync(LoanDTO loanDto)
    {
        await _uow.BeginTransactionAsync();

        var loanUser = await ValidateUserAsync(loanDto.UserId);
        var loanBook = await ValidateBookAsync(loanDto.BookId);

        if (loanBook.IsBorrowed)
        {
            throw new ArgumentException($"Book {loanBook.Title} is already borrowed.");
        }

        await UpdateBookStatusAsync(loanBook.Id, true);

        const int loanDurationDays = 14;

        var newLoan = new Loan
        {
            Id = Guid.NewGuid(),
            BookId = loanDto.BookId,
            UserId = loanDto.UserId,
            LoanDate = loanDto.LoanDate,
            ReturnDate = loanDto.LoanDate.AddDays(loanDurationDays),

            User = loanUser,
            Book = loanBook
        };

        await _loanRepository.AddAsync(newLoan);
        await _uow.CommitTransactionAsync();

        return newLoan;
    }

    public async Task<Loan> UpdateLoanAsync(Guid bookId)
    {
        var book = await ValidateBookAsync(bookId);
        await UpdateBookStatusAsync(book.Id, false);

        var loan = await _loanRepository.FindSpecificLoanByBookIdAsync(bookId);

        DateTime returnDate = DateTime.UtcNow;
        const decimal dailyFineRate = 3;

        loan.MarkAsReturned(returnDate, dailyFineRate);

        await _loanRepository.Update(loan);
        await _uow.CommitTransactionAsync();

        return loan;
    }

    private async Task<User> ValidateUserAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException($"User with ID {userId} does not exist.");
        }
        return user;
    }

    private async Task<Book> ValidateBookAsync(Guid bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book == null)
        {
            throw new ArgumentException($"Book with ID {bookId} does not exist.");
        }
        return book;
    }

    public async Task UpdateBookStatusAsync(Guid bookId, bool isBorrowed)
    {
        var book = await ValidateBookAsync(bookId);

        book.IsBorrowed = isBorrowed;
        await _bookRepository.Update(book);
    }
}
