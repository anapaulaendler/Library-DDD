using Library.Domain.Interfaces;
using Library.Domain.Models;

namespace Library.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, IUnitOfWork uow, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _uow = uow;
        _tokenService = tokenService;
    }

    public async Task CreateUserAsync(User user)
    {
        await _uow.BeginTransactionAsync();
        ValidateEmail(user.Email);
        ValidatePassword(user.Password);

        var newUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role
        };

        await _userRepository.AddAsync(newUser);
        await _uow.CommitTransactionAsync();
    }

    public async Task<string> LoginAsync(UserLoginDTO userLoginDTO)
    {
        var user = await _userRepository.GetUserByEmailAsync(userLoginDTO.UserEmail);
        if (user == null || user.Password != userLoginDTO.Password)
            throw new UnauthorizedAccessException("Invalid credentials");

        return await _tokenService.GenerateTokenAsync(user);
    }

    private void ValidatePassword(string password)
    {
        if (password.Length < 6)
        {
            throw new InvalidDataException("The password has to have more than 5 characters.");
        } else if (password.Length > 50)
        {
            throw new InvalidDataException("The password cannot have more than 50 characters.");
        } 
    }

    private async void ValidateEmail(string email)
    {
        User user = await _userRepository.GetUserByEmailAsync(email);

        if (user is not null)
        {
            throw new InvalidDataException("Este e-mail já está sendo utilizado.");
        }
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
