using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public class DatabaseSettings
        {
            public string DatabaseType { get; set; }
        }
        public static IConfiguration Configuration { get; set; }
        
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;
            var databaseSection = Configuration.GetSection("Database");
            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
            var databaseSettings = databaseSection.Get<DatabaseSettings>();

            if (databaseSettings.DatabaseType == "SQLServer")
            {
                services.AddDbContext<DataContext, DataContextSQLServer>(ConfigureSQLServer);
            }else  
            {
                services.AddDbContext<DataContext, DataContextPostGreSQL>(ConfigurePostgresSQL);
            }
            return services;
        }
        
        private static void ConfigurePostgresSQL(DbContextOptionsBuilder options)
        {
            string postgresSqlConnectionString = Configuration.GetConnectionString("PostGreSQLConnectionString");
            options.UseNpgsql(postgresSqlConnectionString);
            options.EnableSensitiveDataLogging();
        }

        private static void ConfigureSQLServer(DbContextOptionsBuilder options)
        {
            string sqlServerConnectionString = Configuration.GetConnectionString("SQLServerConnectionString");

            options.UseSqlServer(sqlServerConnectionString);
            options.EnableSensitiveDataLogging();
        }
    }
    
}