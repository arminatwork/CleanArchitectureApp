using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
