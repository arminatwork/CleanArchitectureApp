using CA.SharedKernel.Domain;
using CA.SharedKernel.Infrastructure.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace CA.SharedKernel.Infrastructure.Repositories;

public class Repository<TEntity> : QueryRepository<TEntity>, IRepository<TEntity> where TEntity : AuditableEntity
{

    private readonly DbContext _context;

    public Repository(DbContext context) : base(context)
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
