using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface ILoanRepository : IRepositoryBase<Loan>
{
    Task<List<Loan>> GetLoansByUserAsync(Guid id);
    Task<List<Loan>> GetLoansByBookAsync(Guid id);
    Task<decimal> GetUserTotalFineAsync(Guid id);
    Task<Loan> FindSpecificLoanByBookIdAsync(Guid bookId);
}