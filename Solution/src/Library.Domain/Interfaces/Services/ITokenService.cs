using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user);
}
