using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infra.Context;

namespace Library.Infra.Repositories;

public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
{
    public LoanRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public List<Loan> GetLoansByBook(Guid id)
    {
        List<Loan> bookLoans = [];
        bookLoans = _dbSet.Where(x => x.BookId == id).ToList();

        return bookLoans;
    }

    public List<Loan> GetLoansByUser(Guid id)
    {
        List<Loan> userLoans = [];
        userLoans = _dbSet.Where(x => x.UserId == id).ToList();

        return userLoans;
    }

    public decimal GetUserTotalFine(Guid id)
    {
        List<Loan> userLoans = GetLoansByUser(id);
        decimal totalFine = 0;

        foreach (Loan loan in userLoans)
        {
            totalFine += loan.Fine;
        }

        return totalFine;
    }
}
