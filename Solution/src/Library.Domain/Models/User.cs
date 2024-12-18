using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class User : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Role Role { get; set; }
}
