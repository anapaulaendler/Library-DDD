using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class Loan : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal? Fine { get; set; }

    public required User User { get; set; }
    public required Book Book { get; set; }
}
