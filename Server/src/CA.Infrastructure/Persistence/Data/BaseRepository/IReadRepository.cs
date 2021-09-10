using CA.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Data.BaseRepository
{
    public interface IReadRepository<TEntity> where TEntity : AuditableEntity
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(params object[] ids);
        ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        bool IsExists(Expression<Func<TEntity, bool>> predicate);
    }
}
