using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<User> GetUserByEmailAsync(string userEmail)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Email == userEmail);

        if (entity is null)
        {
            throw new KeyNotFoundException();
        }

        return entity;
    }
}