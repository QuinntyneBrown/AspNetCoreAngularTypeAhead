using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AspNetAngularTypeAhead.Api.Models;

namespace AspNetAngularTypeAhead.Api.Data
{
    public class AspNetAngularTypeAheadDbContext: DbContext, IAspNetAngularTypeAheadDbContext
    {
        public AspNetAngularTypeAheadDbContext(DbContextOptions options)
            :base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<ToDo> ToDos { get; private set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
