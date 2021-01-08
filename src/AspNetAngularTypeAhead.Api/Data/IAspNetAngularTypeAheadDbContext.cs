using AspNetAngularTypeAhead.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetAngularTypeAhead.Api.Data
{
    public interface IAspNetAngularTypeAheadDbContext
    {
        DbSet<ToDo> ToDos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
