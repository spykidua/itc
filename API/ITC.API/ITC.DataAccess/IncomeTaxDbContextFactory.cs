using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ITC.DataAccess
{
    public class IncomeTaxDbContextFactory : IDesignTimeDbContextFactory<IncomeTaxDbContext>
    {
        private const string ConnectionStringName = "DefaultConnection";
        private const string EnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";

        public IncomeTaxDbContext CreateDbContext(string[] args)
        {
            var currentEnv = Environment.GetEnvironmentVariable(EnvironmentVariableName);

            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true)
                 .AddJsonFile($"appsettings.{currentEnv}.json", true)
                 .Build();

            var optionsBuilder = new DbContextOptionsBuilder<IncomeTaxDbContext>();
            var connectionString = config.GetConnectionString(ConnectionStringName)
                                   ?? config[ConnectionStringName];

            Console.WriteLine(connectionString);

            optionsBuilder.UseSqlServer(connectionString);

            return new IncomeTaxDbContext(optionsBuilder.Options);
        }
    }
}
