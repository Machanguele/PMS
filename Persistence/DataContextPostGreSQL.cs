using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContextPostGreSQL : DataContext
    {
        public DataContextPostGreSQL(DbContextOptions<DataContextPostGreSQL> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}