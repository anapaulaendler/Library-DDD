using Library.Domain.Interfaces;
using Library.Domain.Models;

namespace Library.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;

    public UserService(IUserRepository userRepository, IUnitOfWork uow)
    {
        _userRepository = userRepository;
        _uow = uow;
    }

    public async Task CreateUserAsync(User user)
    {
        await _uow.BeginTransactionAsync();

        var newUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };

        await _userRepository.AddAsync(newUser);
        await _uow.CommitTransactionAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _uow.BeginTransactionAsync();

        var user = await GetUserByIdAsync(id);

        await _userRepository.Delete(user);
        await _uow.CommitTransactionAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var users = await _userRepository.GetAsync();

        return users;
    }

    public async Task<User> UpdateUserAsync(Guid id, User updatedUser)
    {
        await _uow.BeginTransactionAsync();
        var user = await GetUserByIdAsync(id);

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;

        await _userRepository.Update(user);
        await _uow.CommitTransactionAsync();

        return user;
    }
}
