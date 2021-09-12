using CA.SharedKernel.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace CA.SharedKernel.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IQueryRepository<TEntity> where TEntity : AuditableEntity
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task SaveAsync(CancellationToken cancellationToken);
        void Save();
    }
}
