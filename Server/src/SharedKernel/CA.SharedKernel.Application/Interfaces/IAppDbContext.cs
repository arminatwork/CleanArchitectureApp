using System.Threading;
using System.Threading.Tasks;

namespace CA.SharedKernel.Application.Interfaces
{
    public interface IAppDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}