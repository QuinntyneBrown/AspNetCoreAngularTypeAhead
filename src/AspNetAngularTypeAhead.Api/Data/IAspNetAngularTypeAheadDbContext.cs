using AspNetAngularTypeAhead.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        ChangeTracker ChangeTracker { get; }
    }

    public interface IAspNetAngularTypeAheadDbContext: IDbContext
    {
        DbSet<ToDo> ToDos { get; }
    }
}
