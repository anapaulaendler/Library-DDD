using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Repositories;

public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
{
    public LoanRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<Loan> FindSpecificLoanByBookIdAsync(Guid bookId)
    {
        var loan = await _dbSet
            .Where(l => l.BookId == bookId && l.ReturnDate == null)
            .ToListAsync(); 

        if (loan is null || !loan.Any())
        {
            throw new ArgumentException($"No active loan found for the book with ID {bookId}.");
        }

        var closestLoan = loan
            .OrderBy(l => Math.Abs((l.LoanDate - DateTime.Now).Ticks))
            .FirstOrDefault();

        if (closestLoan == null)
        {
            throw new ArgumentException($"No active loan found for the book with ID {bookId}.");
        }

        return closestLoan;
    }

    public async Task<List<Loan>> GetLoansByBookAsync(Guid id)
    {
        List<Loan> bookLoans = [];
        bookLoans = await _dbSet.Where(x => x.BookId == id).ToListAsync();

        return bookLoans;
    }

    public async Task<List<Loan>> GetLoansByUserAsync(Guid id)
    {
        List<Loan> userLoans = [];
        userLoans = await _dbSet.Where(x => x.UserId == id).ToListAsync();

        return userLoans;
    }

    public async Task<decimal> GetUserTotalFineAsync(Guid id)
    {
        List<Loan> userLoans = await GetLoansByUserAsync(id);

        return userLoans.Sum(l => l.Fine);
    }
}
