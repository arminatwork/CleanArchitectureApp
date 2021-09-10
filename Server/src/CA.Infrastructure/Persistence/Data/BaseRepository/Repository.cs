using CA.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence.Data.BaseRepository
{
    public class Repository<TEntity> : QueryRepository<TEntity>, IRepository<TEntity> where TEntity : AuditableEntity
    {

        private readonly AppDbContext _context;

        public Repository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Entities.AddAsync(entity, cancellationToken);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}