using Library.Domain.Interfaces;

namespace Library.Domain.Models;

public class UserLoginDTO
{
    public required string UserEmail { get; set; }
    public required string Password { get; set; }
}