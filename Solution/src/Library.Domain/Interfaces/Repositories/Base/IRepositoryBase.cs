using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Domain.Interfaces;

namespace Library.Domain.Interfaces;
public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task Delete(TEntity entity);
    Task Update(TEntity entity);
}