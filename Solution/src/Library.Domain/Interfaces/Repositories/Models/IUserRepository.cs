using Library.Domain.Models;

namespace Library.Domain.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User> GetUserByEmailAsync(string userEmail);
}