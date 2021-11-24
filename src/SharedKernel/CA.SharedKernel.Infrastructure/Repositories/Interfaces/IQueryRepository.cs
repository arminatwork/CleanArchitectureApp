using CA.SharedKernel.Domain;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CA.SharedKernel.Infrastructure.Repositories.Interfaces;

public interface IQueryRepository<TEntity> where TEntity : AuditableEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    TEntity GetById(params object[] ids);
    ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    Task<bool> IsExistsAsync(CancellationToken cancellationToken);
    bool IsExists();
    Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    bool IsExists(Expression<Func<TEntity, bool>> predicate);
}
