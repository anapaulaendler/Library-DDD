using Library.Domain.Interfaces;
using Library.Domain.Models;
using Library.Infra.Context;

namespace Library.Infra.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext appContext) : base(appContext)
    {
    }
}