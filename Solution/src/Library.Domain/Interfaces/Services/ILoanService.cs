using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface ILoanService
{
    Task<Loan> NewLoanAsync(LoanDTO loan);
    Task<List<Loan>> GetLoansAsync();
    Task<List<Loan>> GetLoansByUser(Guid id);
    Task<List<Loan>> GetLoansByBook(Guid id);
    Task<decimal> GetUserTotalFine(Guid id);
    Task<Loan> UpdateLoan(Guid bookId);
}