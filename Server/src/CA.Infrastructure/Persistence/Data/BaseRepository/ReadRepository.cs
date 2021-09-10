using CA.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Data.BaseRepository
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : AuditableEntity
    {
        public DbSet<TEntity> Entities { get; }
        public IQueryable<TEntity> Table => Entities;
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
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
}
