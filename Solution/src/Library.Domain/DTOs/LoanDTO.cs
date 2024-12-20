using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class LoanDTO
{
    public required string UserEmail { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
}
