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

    public Task<List<Loan>> GetLoansByBook(Guid id)
    {
        throw new NotImplementedException();
        // var bookLoans = _loanRepository.GetLoansByBook(id);

        // return bookLoans;
    }

    public Task<List<Loan>> GetLoansByUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetUserTotalFine(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> NewLoanAsync(LoanDTO loan)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> UpdateLoan(Guid bookId)
    {
        throw new NotImplementedException();
    }
}
