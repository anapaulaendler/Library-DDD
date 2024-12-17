using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> UpdateUserAsync(Guid id, User user);
    Task DeleteUserAsync(Guid id);
}