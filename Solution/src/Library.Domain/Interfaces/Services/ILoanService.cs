using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface ILoanService
{
    Task<Loan> NewLoanAsync(LoanDTO loan);
    Task<List<Loan>> GetLoansAsync();
    Task<List<Loan>> GetLoansByUserAsync(Guid id);
    Task<List<Loan>> GetLoansByBookAsync(Guid id);
    Task<string> GetUserTotalFineAsync(Guid id);
    Task<Loan> UpdateLoanAsync(Guid bookId);
}