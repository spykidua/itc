using ITC.DataAccess.Interfaces;
using ITC.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ITC.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<IncomeTaxDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, IncomeTaxDbContext>(provider => provider.GetService<IncomeTaxDbContext>());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
            
        }
    }
}
