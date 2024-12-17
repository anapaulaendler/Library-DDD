using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface ILoanRepository : IRepositoryBase<Loan>
{
    List<Loan> GetLoansByUser(Guid id);
    List<Loan> GetLoansByBook(Guid id);
    decimal GetUserTotalFine(Guid id);
}