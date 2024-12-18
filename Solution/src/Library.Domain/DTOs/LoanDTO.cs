using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class LoanDTO
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
}
