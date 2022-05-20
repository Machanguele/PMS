using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContextSQLServer : DataContext
    {
        public DataContextSQLServer(DbContextOptions<DataContextSQLServer> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}