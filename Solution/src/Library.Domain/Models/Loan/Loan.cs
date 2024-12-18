using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class Loan : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Fine { get; set; }

    public required User User { get; set; }
    public required Book Book { get; set; }

    public void CalculateFine(decimal dailyFineRate)
    {
        if (ReturnDate.HasValue && ReturnDate.Value > DueDate)
        {
            var overdueDays = (ReturnDate.Value - DueDate).Days;
            Fine = overdueDays * dailyFineRate;
        }
        else if (!ReturnDate.HasValue && DateTime.Now > DueDate)
        {
            var overdueDays = (DateTime.Now - DueDate).Days;
            Fine = overdueDays * dailyFineRate;
        }
    }

    public void MarkAsReturned(DateTime returnDate, decimal dailyFineRate)
    {
        ReturnDate = returnDate;
        CalculateFine(dailyFineRate);
    }

}