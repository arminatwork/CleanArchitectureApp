using CA.SharedKernel.Domain;
using CA.SharedKernel.Infrastructure.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CA.SharedKernel.Infrastructure.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : AuditableEntity
{
    public DbSet<TEntity> Entities { get; }
    public IQueryable<TEntity> Table => Entities;
    public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    private readonly DbContext _context;

    public QueryRepository(DbContext context)
    {
        _context = context;
        Entities = _context.Set<TEntity>();
    }

    /// <summary>
    /// list of <see cref="TEntity"/> by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return TableNoTracking.Where(predicate);
    }

    /// <summary>
    /// find item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    public virtual TEntity GetById(params object[] ids)
    {
        return Entities.Find(ids);
    }

    /// <summary>
    /// find async item in <see cref="TEntity"/> by tracking.
    /// </summary>
    /// <returns></returns>
    public virtual ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return Entities.FindAsync(ids, cancellationToken);
    }

    /// <summary>
    /// is exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsExists()
    {
        return TableNoTracking.Any();
    }

    /// <summary>
    /// is exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<bool> IsExistsAsync(CancellationToken cancellationToken)
    {
        return await TableNoTracking.AnyAsync();
    }

    /// <summary>
    /// is exists this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual bool IsExists(Expression<Func<TEntity, bool>> predicate)
    {
        return TableNoTracking.Any(predicate);
    }

    /// <summary>
    /// is exists async this <see cref="TEntity"/> in database by no tracking.
    /// </summary>
    /// <returns></returns>
    public virtual async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await TableNoTracking.AnyAsync(predicate);
    }
}
